using System;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_07
{
    [TestClass]
    public class Finally
    {
        [TestMethod]
        public void TestMethod1()
        {
            // this is not really a test but
            // take a look at the test output
            M1();
            // == with catch in M3 ==
            //catch in M3
            //finally in M3
            //finally in M2
            //finally in M1

            // == without catch in M3 ==
            //finally in M3
            //catch in M2
            //finally in M2
            //finally in M1
        }

        private void M1()
        {
            try { M2(); }
            catch (Exception) { Debug.WriteLine("catch in M1"); }
            finally { Debug.WriteLine("finally in M1"); }
        }

        private void M2()
        {
            try { M3(); }
            catch (Exception) { Debug.WriteLine("catch in M2"); }
            finally { Debug.WriteLine("finally in M2"); }
        }

        private void M3()
        {
            try { Crash(); }
            finally { Debug.WriteLine("finally in M3"); }
        }

        private void Crash() => throw new Exception("Boom");



        private class Resource : IDisposable
        {
            public void Dispose()
            {
            }
        }

        void FinallyBlock()
        {
            Resource res = new Resource();
            try
            {
                Console.WriteLine();
            }
            finally
            {
                res?.Dispose();
            }
        }

        void UsingStatement()
        {
            using (var res = new Resource())
            {
                Console.WriteLine();
            }
        }

    }
}
