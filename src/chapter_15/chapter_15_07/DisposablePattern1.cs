using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_07
{
    /// <summary>
    /// This test class doesn't make any assert
    /// </summary>
    [TestClass]
    public class DisposablePattern1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var s1 = new MyRefStruct();
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            //await using var s2 = new MyRefStruct();   // Error!
        }

        [TestMethod]
        public Task TestMethod3()
        {
            var s2 = new MyRefStruct();
            Task result;
            try
            {
            }
            finally
            {
                result = s2.DisposeAsync().AsTask();
            }

            return result;
        }

        [TestMethod]
        public void TestMethod4()
        {
            // dispose pattern not allowed with Dispose
            //using var s1 = new MyStruct();
        }


        [TestMethod]
        public async Task TestMethod5()
        {
            // dispose pattern allowed with DisposeAsync
            await using var s1 = new MyStruct();

            //using var s2 = new MyStruct(); // dispose pattern not allowed on Dispose
        }

        public ref struct MyRefStruct
        {
            public void Dispose() => Debug.WriteLine("Dispose");
            public ValueTask DisposeAsync()
            {
                Debug.WriteLine("DisposeAsync");
                return default(ValueTask);
            }
        }

        public struct MyStruct
        {
            public void Dispose() => Debug.WriteLine("Dispose");
            public ValueTask DisposeAsync()
            {
                Debug.WriteLine("DisposeAsync");
                return default(ValueTask);
            }
        }

    }
}
