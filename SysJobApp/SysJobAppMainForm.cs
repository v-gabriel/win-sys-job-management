using Microsoft.Diagnostics.Runtime;
using SysJobApp.Delegates;
using SysJobApp.Services;
using System.Diagnostics;

namespace SysJobApp
{
    public partial class SysJobAppMainForm : Form
    {
        private int rollbackMsTrigger = 10000;
        private int countTo = 100;
        
        private List<Process> processes = new List<Process>();
        private ProcessThreadCollection threads;
        private List<ProcessThread> selectedThreads = new List<ProcessThread>();

        CancellationTokenSource mockThreadCancellationToken = new();

        private List<Thread> managedThreads = new List<Thread>();
        private Dictionary<int, uint> mappedThreadIds = new Dictionary<int, uint>();
        private List<System.Threading.ThreadState> inactiveStates = new List<System.Threading.ThreadState>()
        {
            System.Threading.ThreadState.Suspended
        };

        #region App
        public SysJobAppMainForm()
        {
            InitializeComponent();

            InitMainThreadProtection();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            ProcessThreadHandlerService.HandleResumeSuspendedThreads();

            SuspendActiveThreads();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            CounterService counterService = new CounterService(
                this.countTo,
                new IntDelegate(DelegateMockThreadGUIUpdate)
            );

            var mockThread = new Thread(new ThreadStart(() =>
            {
                counterService.Execute(mockThreadCancellationToken.Token);
            }));
            mockThread.Name = $"CounterThread";
            mockThread.Start();

            this.managedThreads.Add(mockThread);

            RollbackService rollbackService =
                new RollbackService(
                    rollbackMsTrigger,
                    DelegateProcessRefreshUpdate
                );
            var rollbackThread = new Thread(new ThreadStart(() =>
            {
                rollbackService.Execute(mockThreadCancellationToken.Token);
            }));
            rollbackThread.Name = "RollbackThread";
            rollbackThread.Start();

            this.managedThreads.Add(rollbackThread);

            MapManagedAndSystemThreads();
            UpdateProcessesList();
        }

        private void processes_refreshBtn_Click(object sender, EventArgs e)
        {
            UpdateProcessesList();
        }

        private void process_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThreadsList();
        }

        private void threads_pauseAllBtn_Click(object sender, EventArgs e)
        {
            if (threads == null || threads.Count == 0)
            {
                return;
            }

            for (int i = 0; i < threads.Count; i++)
            {
                ProcessThreadHandlerService.HandleSuspendThread(threads[i].Id);
            }

            UpdateProcessesList();
        }

        private void threads_pauseSelectedBtn_Click(object sender, EventArgs e)
        {
            if (threads == null || threads.Count == 0)
            {
                return;
            }

            this.MapSelectedThreads();

            foreach (var thread in this.selectedThreads)
            {
                ProcessThreadHandlerService.HandleSuspendThread(thread.Id);
            }

            UpdateProcessesList();
        }

        private void threads_resumeAllBtn_Click(object sender, EventArgs e)
        {
            if (threads == null || threads.Count == 0)
            {
                return;
            }

            this.MapSelectedThreads();

            foreach (var thread in this.selectedThreads)
            {
                ProcessThreadHandlerService.HandleResumeThread(thread.Id);
            }

            UpdateProcessesList();
        }

        private void threads_resumeSelectedBtn_Click(object sender, EventArgs e)
        {
            if (threads == null || threads.Count == 0)
            {
                return;
            }

            for (int i = 0; i < threads.Count; i++)
            {
                ProcessThreadHandlerService.HandleResumeThread(threads[i].Id);
            }

            UpdateProcessesList();
        }

        private void main_threadProtectionChecbox_CheckedChanged(object sender, EventArgs e)
        {
            if (main_threadProtectionChecbox.Checked)
            {
                ProcessThreadHandlerService.isMainThreadProtected = true;
            }
            else
            {
                ProcessThreadHandlerService.isMainThreadProtected = false;
            }
        }
        #endregion

        #region Helpers
        private void DelegateProcessRefreshUpdate()
        {
            if (IsHandleCreated)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    UpdateProcessesList();
                });
            }
        }

        public void DelegateMockThreadGUIUpdate(int value)
        {
            if (IsHandleCreated)
            {
                mockThread_valueLabel.BeginInvoke((MethodInvoker)delegate
                {
                    mockThread_valueLabel.Text = $"{value} / {this.countTo}";
                    UpdateMockThreadInfo();
                });
            }
        }

        private void UpdateMockThreadInfo()
        {
            mockThread_infoLabel.Text =
                $"ProcessId: {Process.GetCurrentProcess().Id}" +
                $" - ThreadId: {this.mappedThreadIds[this.managedThreads[0].ManagedThreadId]}" +
                $" - Status: {this.managedThreads[0].ThreadState}";
        }

        private void UpdateProcessesList()
        {
            var isSelected = process_listView.SelectedIndex == -1 ? false : true;
            var identifier = String.Empty;
            if (isSelected)
            {
                identifier = process_listView.Items[process_listView.SelectedIndex].ToString();
            }

            process_listView.Items.Clear();

            this.processes = new List<Process>();
            this.processes.AddRange(Process.GetProcesses());

            foreach (var process in this.processes)
            {
                var processInfo = $"{process.Id} - {process.ProcessName}";
                process_listView.Items.Add(
                    processInfo
                );
            }

            if (isSelected)
            {
                var id = int.Parse(identifier.Split("-")[0].Trim());
                process_listView.SelectedIndex = this.processes.IndexOf(this.processes.SingleOrDefault(x => x.Id.Equals(id)));
            }

            process_listView.Refresh();
        }

        private void UpdateThreadsList()
        {
            var isSelected = thread_listView.SelectedIndex == -1 ? false : true;
            var identifier = String.Empty;
            if (isSelected)
            {
                identifier = thread_listView.Items[thread_listView.SelectedIndex].ToString();
            }

            thread_listView.Items.Clear();

            this.threads = this.processes[process_listView.SelectedIndex].Threads;

            var tempThreads = new List<ProcessThread>();
            for (int i = 0; i < threads.Count; i++)
            {
                var threadInfo = $"{threads[i].Id} - {threads[i].ThreadState}";
                if (threads[i].ThreadState == System.Diagnostics.ThreadState.Wait)
                {
                    threadInfo += $" - {threads[i].WaitReason}";
                }
                thread_listView.Items.Add(
                    threadInfo
                );
                tempThreads.Add(threads[i]);
            }

            if (isSelected)
            {
                var id = int.Parse(identifier.Split("-")[0].Trim());
                thread_listView.SelectedIndex =
                    this.threads.IndexOf(
                        tempThreads.SingleOrDefault(x => x.Id.Equals(id))
                    );
            }

            UpdateMockThreadInfo();

            thread_listView.Refresh();
        }

        private void MapSelectedThreads()
        {
            this.selectedThreads = new List<ProcessThread>();
            foreach (var selectedItem in thread_listView.SelectedItems)
            {
                this.selectedThreads.Add(this.threads[thread_listView.Items.IndexOf(selectedItem)]);
            }
        }

        private void MapManagedAndSystemThreads()
        {
            using (DataTarget dataTarget = DataTarget.CreateSnapshotAndAttach(Process.GetCurrentProcess().Id))
            using (ClrRuntime runtime = dataTarget.ClrVersions.Single().CreateRuntime())
            {
                foreach (ClrThread thread in runtime.Threads)
                {
                    if (this.managedThreads.SingleOrDefault(x => x.ManagedThreadId.Equals(thread.ManagedThreadId)) != null)
                    {
                        Console.WriteLine(
                            $"[Info] Mapped thread " +
                            $"{this.managedThreads.SingleOrDefault(x => x.ManagedThreadId.Equals(thread.ManagedThreadId))?.Name ?? null} " +
                            $"- {thread.ManagedThreadId} " +
                            $"- {thread.OSThreadId}");
                        this.mappedThreadIds.Add(thread.ManagedThreadId, thread.OSThreadId);
                    }
                }
            }
        }

        private void SuspendActiveThreads()
        {
            this.mockThreadCancellationToken.Cancel();

            foreach (var dict in this.mappedThreadIds)
            {
                var thread = this.managedThreads.SingleOrDefault(x => x.ManagedThreadId.Equals(dict.Key));
                while (this.inactiveStates.Contains(thread.ThreadState))
                {
                    ProcessThreadHandlerService.HandleResumeThread((int)this.mappedThreadIds[dict.Key]);
                }
            }

            this.mockThreadCancellationToken.Dispose();
        }

        private void InitMainThreadProtection()
        {
            var mainThreadId = Process.GetCurrentProcess().Threads[0].Id;

            Console.WriteLine($"[ProcessThreadHandler] / [Info] Enabled main thread  protection ({mainThreadId}).");
            ProcessThreadHandlerService.InitMainThreadId(mainThreadId);

            main_threadProtectionChecbox.Checked = true;
        }
        #endregion
    }
}