using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SysJobApp.Services
{
    public static class ProcessThreadHandlerService
    {
        #region DLL dependencies
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
        #endregion

        public static bool isMainThreadProtected { get; set; } = false;
        public static int? mainThreadId
        {
            get; private set;
        } = null;

        public static void InitMainThreadId(int value)
        {
            if (mainThreadId == null)
            {
                mainThreadId = value;
                isMainThreadProtected = true;
            }
        }

        public readonly static Dictionary<int, int?> resumePidCountDict = new Dictionary<int, int?>();

        public static void HandleResumeSuspendedThreads()
        {
            var tempResumePidCountDict = new Dictionary<int, int?>(resumePidCountDict);
            foreach (int pid in tempResumePidCountDict.Keys)
            {
                for (int i = 0; i < tempResumePidCountDict[pid]; i++)
                {
                    HandleResumeThread(pid);
                    resumePidCountDict.Remove(pid);
                }
            }
        }

        public static void HandleResumeThread(int pid)
        {
            IntPtr pOpenThread = IntPtr.Zero;

            try
            {
                pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pid);

                if (pOpenThread == IntPtr.Zero)
                {
                    Console.WriteLine($"[ProcessThreadHandler] / [Error] Invalid thread pointer on PID: {pid}. Aborting action.");
                    return;
                }

                ResumeThread(pOpenThread);

                Console.WriteLine($"[ProcessThreadHandler] / [Info] Resumed thread with PID: {pid}.");

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

        public static void HandleSuspendThread(int pid)
        {
            if(pid == mainThreadId && isMainThreadProtected)
            {
                Console.WriteLine($"[Error] Cannot suspend main thread ({pid}). Aborting action.");

                return;
            }

            IntPtr pOpenThread = IntPtr.Zero;

            try
            {
                pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pid);

                if (pOpenThread == IntPtr.Zero)
                {
                    Console.WriteLine($"[Error] Invalid thread pointer on PID: {pid}. Aborting action.");

                    return;
                }

                var count = resumePidCountDict.GetValueOrDefault(pid) != null ? resumePidCountDict[pid]++ : 1;
                var isNew = resumePidCountDict.TryAdd(pid, count);
                if (!isNew)
                {
                    resumePidCountDict[pid]++;
                }
                SuspendThread(pOpenThread);

                Console.WriteLine($"[ProcessThreadHandler] / [Info] Suspended thread with PID: {pid}.");

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
    }
}
