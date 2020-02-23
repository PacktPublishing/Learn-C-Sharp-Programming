using System;
using System.Threading.Tasks;

namespace chapter_12_03_09
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var c = new CancellingATask();
            await c.CancellingTask();
            Console.ReadKey();
        }
    }
}
