using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chapter_12_03_09
{
    class CancellingATask
    {
        public async Task CancellingTask()
        {
            CancellationTokenSource cts2 = new
                CancellationTokenSource(TimeSpan.FromSeconds(2));
            var tok2 = cts2.Token;

            try
            {
                await WorkForever1Async(tok2);
                await WorkForever2Async(tok2);
                await WorkForever3Async(tok2);
                Console.WriteLine("let's continue");
            }
            catch (TaskCanceledException err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public async Task WorkForever1Async(
            CancellationToken ct = default(CancellationToken))
        {
            while (true)
            {
                await Task.Delay(5000, ct);
            }
        }

        public Task WorkForever2Async(
            CancellationToken ct = default(CancellationToken))
        {
            while (true)
            {
                Thread.Sleep(5000);
                if (ct.IsCancellationRequested) return Task.FromCanceled(ct);
            }
        }

        public async Task WorkForever3Async(
            CancellationToken ct = default(CancellationToken))
        {
            while (true)
            {
                await Task.Delay(5000);
                if (ct.IsCancellationRequested) return;
            }
        }
    }
}
