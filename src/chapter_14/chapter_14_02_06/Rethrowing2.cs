using System;
using System.IO;
using System.Runtime.ExceptionServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_06
{
    [TestClass]
    public class Rethrowing2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<NotImplementedException>(() => Foo());
        }


        public void Foo()
        {
            ExceptionDispatchInfo exceptionDispatchInfo = null;
            try
            {
                ExecuteFunctionThatThrows();
            }
            catch (Exception ex)
            {
                exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
            }

            // do something you cannot do in the catch block

            // rethrow
            if (exceptionDispatchInfo != null)
                exceptionDispatchInfo.Throw();
        }

        private void ExecuteFunctionThatThrows()
        {
            throw new NotImplementedException();
        }

        private ExceptionDispatchInfo CaptureException()
        {
            try
            {
                string x = null;
                x.Trim();
                return null;
            }
            catch (Exception err)
            {
                return ExceptionDispatchInfo.Capture(err);
            }
        }


    }
}
