using System;
using System.Threading;
using System.Threading.Tasks;

namespace chapter_12_03_06
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var t = new Task(() => Thread.Sleep(30000),
                TaskCreationOptions.LongRunning);

            // experiment with either of the following:
            t.Start();
            //await t;

            Console.ReadKey();
        }
    }
}
