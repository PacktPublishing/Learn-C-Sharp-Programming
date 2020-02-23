using System;
using System.Threading.Tasks;

namespace chapter_12_03_13
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sc = new SyncContext();
            await sc.AsyncTest1();
            await sc.AsyncLoop();
            Console.ReadKey();
        }
    }
}
