using System;

namespace chapter_15_05
{
    public class Program
    {
        public static void Main()
        {
            Run1();
            Run2();
            Run3();
            Console.ReadKey();
        }

        static void Run1()
        {
            Console.WriteLine();
            Console.WriteLine("Run1");
            using (var x = new DisposableClass())
            {
                Console.WriteLine($"using {nameof(DisposableClass)}");
            }   // Dispose is called
        }

        static void Run2()
        {
            Console.WriteLine();
            Console.WriteLine("Run2");
            using (var x = new Disposable1())
            {
                Console.WriteLine($"using {nameof(Disposable1)}");
                using (var y = new Disposable2())
                {
                    Console.WriteLine($"using {nameof(Disposable2)}");
                    using (var z = new Disposable3())
                    {
                        Console.WriteLine($"using {nameof(Disposable3)}");
                    }
                }
            }
        }

        static void Run3()
        {
            Console.WriteLine();
            Console.WriteLine("Run3");
            using var x = new Disposable1();
            Console.WriteLine($"using {nameof(Disposable1)}");

            using var y = new Disposable2();
            Console.WriteLine($"using {nameof(Disposable2)}");

            using var z = new Disposable3();
            Console.WriteLine($"using {nameof(Disposable3)}");

        }// here x, y and z will be disposed


    }

    class DisposableClass : IDisposable
    {
        public void Dispose() => Console.WriteLine("== Dispose! ==");
    }

    class Disposable1 : IDisposable
    {
        public void Dispose() => Console.WriteLine("Disposable1");
    }

    class Disposable2 : IDisposable
    {
        public void Dispose() => Console.WriteLine("Disposable2");
    }

    class Disposable3 : IDisposable
    {
        public void Dispose() => Console.WriteLine("Disposable3");
    }

}
