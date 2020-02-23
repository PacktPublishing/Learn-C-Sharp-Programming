using System;
using System.Threading.Tasks;

namespace chapter_12_03_10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var test = new MonitorProgress();
            await test.Load(new ConsoleProgress());
            Console.ReadKey();
        }
    }
}
