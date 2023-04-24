using SysJobApp.Delegates;
using SysJobApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysJobApp.Services
{
    public class RollbackService : IThreadExecutable
    {
        private int rollbackMsTrigger;
        private VoidDelegate onRollbackDelegate;

        public RollbackService(int rollbackMsTrigger, VoidDelegate onRollbackDelegate)
        {
            this.rollbackMsTrigger = rollbackMsTrigger;
            this.onRollbackDelegate = onRollbackDelegate;
        }

        public void Execute(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(rollbackMsTrigger);

                if (ProcessThreadHandlerService.resumePidCountDict.Any())
                {
                    Console.WriteLine(
                        $"[RollbackThread] / [Info] Resuming suspended threads."
                    );

                    ProcessThreadHandlerService.HandleResumeSuspendedThreads();

                    this.onRollbackDelegate();
                }
            }
            Console.WriteLine($"[RollbackThread] / [Info] Rollback thread closed.");
        }
    }
}
