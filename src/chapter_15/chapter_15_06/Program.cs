using System;
using System.Threading.Tasks;

namespace chapter_15_06
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SomeMethodAsync1();
            await SomeMethodAsync2();
            Console.ReadKey();
        }

        private static async Task SomeMethodAsync1()
        {
            await using (var x = new AsyncDisposableClass())
            {
                // ...
            }
        }

        private static async Task SomeMethodAsync2()
        {
            await using var x = new AsyncDisposableClass();
            // ...
        }
    }

    public class AsyncDisposableClass : IAsyncDisposable
    {
        public ValueTask DisposeAsync()
        {
            Console.WriteLine("Dispose called");
            return new ValueTask();
        }
    }

}
