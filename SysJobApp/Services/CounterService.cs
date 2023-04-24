using SysJobApp.Delegates;
using SysJobApp.Services.Interfaces;

namespace SysJobApp.Services
{
    public class CounterService : IThreadExecutable
    {
        private int countTo;
        private IntDelegate onIncrementDelegate;

        public CounterService(int countTo, IntDelegate onIncrementDelegate)
        {
            this.countTo = countTo;
            this.onIncrementDelegate = onIncrementDelegate;
        }

        public void Execute(CancellationToken token)
        {
            int i = 0;

            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);

                this.onIncrementDelegate(i);

                Console.WriteLine($"[CounterService] / [Info] Count: {i}");

                if (i >= countTo)
                {
                    break;
                }

                i++;
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"[CounterService] / [Info] Interrupted with cancellation token. Closing in 3 s.");
                Thread.Sleep(3000);
            }

            Console.WriteLine($"[CounterService] / [Info] Counter thread finished.");
        }
    }
}
