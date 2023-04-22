using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SysJobApp
{
    public partial class Form1 : Form
    {
        private int countTo = 100;
        private List<Process> processes = new List<Process>();
        private ProcessThreadCollection threads;
        private List<ProcessThread> selectedThreads = new List<ProcessThread>();

        private Thread testThread;

        #region App
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            Task.Run(() =>
            {
                MockThread ct = new MockThread(this.countTo, new IntCallback(DelegateMockThreadValueUpdate), new VoidCallback(DelegateMockThreadInfoUpdate));

                this.testThread = new Thread(new ThreadStart(() =>
                {
                    ct.Execute();
                }));
                this.testThread.Name = $"MockTestThread";

                this.testThread.Start();
            });
        }

        private void processes_refreshBtn_Click(object sender, EventArgs e)
        {
            UpdateProcessesList();
        }

        private void process_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThreadsList();
        }

        private void thread_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void threads_pauseAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < threads.Count; i++)
            {
                HandleSuspendThread(threads[i].Id);
            }

            UpdateThreadsList();
        }

        private void threads_pauseSelectedBtn_Click(object sender, EventArgs e)
        {
            this.MapSelectedThreads();

            foreach (var thread in this.selectedThreads)
            {
                HandleSuspendThread(thread.Id);
            }

            UpdateThreadsList();
        }

        private void threads_resumeAllBtn_Click(object sender, EventArgs e)
        {
            this.MapSelectedThreads();

            foreach (var thread in this.selectedThreads)
            {
                HandleResumeThread(thread.Id);
            }

            UpdateProcessesList();
        }

        private void threads_resumeSelectedBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < threads.Count; i++)
            {
                HandleResumeThread(threads[i].Id);
            }

            UpdateProcessesList();
        }

        #endregion

        #region Helpers
        public void DelegateMockThreadValueUpdate(int value)
        {
            mockThread_valueLabel.Invoke((MethodInvoker)delegate {
                 mockThread_valueLabel.Text = $"{value} / {this.countTo}";
            });
        }

        public void DelegateMockThreadInfoUpdate()
        {
            var processId = Process.GetCurrentProcess().Id;
            mockThread_valueLabel.Invoke((MethodInvoker)delegate
            {
                UpdateMockThreadInfo();
            });
        }

        private void UpdateMockThreadInfo()
        {
            mockThread_infoLabel.Text = $"At process: {Process.GetCurrentProcess().Id} - Status: {this.testThread.ThreadState}";
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
                thread_listView.SelectedIndex = this.threads.IndexOf(tempThreads.SingleOrDefault(x => x.Id.Equals(id)));
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

        #region Process and thread handling
        // Check for documentation and source in README.md file
        // Use at own risk

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private void HandleResumeThread(int pid)
        {
            IntPtr pOpenThread = IntPtr.Zero;

            try
            {
                pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pid);

                if (pOpenThread == IntPtr.Zero)
                {
                    Console.WriteLine($"Invalid thread pointer on PID{pid}. Aborting action.");
                    return;
                }

                ResumeThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (pOpenThread != IntPtr.Zero)
                {
                    CloseHandle(pOpenThread);
                }
            }
        }

        private void HandleSuspendThread(int pid)
        {
            IntPtr pOpenThread = IntPtr.Zero;

            try
            {
                pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pid);

                if (pOpenThread == IntPtr.Zero)
                {
                    Console.WriteLine($"Invalid thread pointer on PID{pid}. Aborting action.");
                    return;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (pOpenThread != IntPtr.Zero)
                {
                    CloseHandle(pOpenThread);
                }
            }
        }
        #endregion

        #endregion

    }

    public delegate void IntCallback(int value);
    public delegate void VoidCallback();

    public class MockThread
    {
        private int countTo;
        private IntCallback intCallback;
        private VoidCallback voidCallback;


        public MockThread(int countTo, IntCallback intCallback, VoidCallback voidCallback)
        {
            this.countTo = countTo;
            this.intCallback = intCallback;
            this.voidCallback = voidCallback;
        }

        public void Execute()
        {
            this.voidCallback();
            for (int i = 0; i <= countTo; i++)
            {
                Thread.CurrentThread.Join(1000);
                this.intCallback(i);
                Console.WriteLine($"{i}");
            }
            Console.WriteLine($"Finished");
            this.voidCallback();
        }
    }
}