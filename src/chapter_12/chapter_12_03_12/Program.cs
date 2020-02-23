using System;
using System.Threading;
using System.Threading.Tasks;

namespace chapter_12_03_12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Test1();
            await Test2();
            await Test3();
            Console.ReadKey();
        }

        private static async Task Test1()
        {
            var dn = new DeletionNotifier();
            var deleted = await dn.WhenDeleted();
            Console.WriteLine($"Deleted: {deleted.Name}");
        }

        private static async Task Test2()
        {
            var dn = new DeletionNotifier2();
            var deleted = await dn.WhenDeleted();
            Console.WriteLine($"Deleted: {deleted.Name}");
        }

        private static async Task Test3()
        {
            var dn = new DeletionNotifier3();
            while (true)
            {
                var deleted = await dn.WhenDeleted();
                Console.WriteLine($"Deleted: {deleted.Name}");
                Thread.Sleep(2500);
            }
        }
    }
}
