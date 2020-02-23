using System;
using System.Threading.Tasks;

namespace chapter_12_03_08
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var te = new TaskAndExceptions();
            await te.Run();
            Console.ReadKey();
        }
    }
}
