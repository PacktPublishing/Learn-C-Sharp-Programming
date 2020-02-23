using System;
using System.Threading.Tasks;

namespace chapter_12_03_11
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var w = new Parallelizing();
            await w.NeedAll();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                await w.NeedAny();
                Console.WriteLine();
            }
            w.WaitAll();

            Console.ReadKey();
        }
    }
}
