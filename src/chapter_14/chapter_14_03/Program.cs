using System;

namespace chapter_14_03
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var p = new FirstSecondChance();
            //p.TestMethod1();
            //p.TestMethod2();
            //p.TestMethod3();

            var ee = new ExceptionEvent();
            ee.TestMethod1();
        }

        private static void CurrentDomain_FirstChanceException(object sender,
            System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine($"First-Chance. {e.Exception.Message}");
            Dump(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            Console.WriteLine($"Unhandled Exception. IsTerminating: {e.IsTerminating} - {ex.Message}");
            Dump(ex);
        }

        private static void Dump1(Exception err)
        {
            var current = err;
            while (current != null)
            {
                Console.WriteLine(current.InnerException?.Message);
                current = current.InnerException;
            }
        }

        private static void Dump2(Exception err)
        {
            Console.WriteLine(err);
        }

        private static void Dump3(Exception err)
        {
            Console.WriteLine(err.TargetSite.Name);
        }

        private static void Dump(Exception err)
        {
            var be = err.GetBaseException();
            Console.WriteLine($"err:{err.TargetSite.Name} - base:{be.TargetSite.Name}");
        }
    }
}
