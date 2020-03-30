using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_01
{
    [TestClass]
    public class ErrorsVsExceptions
    {
        [TestMethod]
        public void TestMethod1()
        {
            var api = new SomeApi();
            if (api.Begin() == 0)
            {
                if (api.DoWork() == 0)
                {
                    api.End();
                }
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var a = 1;
            var b = 0;
            // division by zero with integers
            Assert.ThrowsException<DivideByZeroException>(() => a / b);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var a = 1.0m;
            var b = 0.0m;
            // division by zero with decimals
            Assert.ThrowsException<DivideByZeroException>(() => a / b);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var a = 1.0;
            var b = 0.0;
            // division by zero with floating points
            Assert.AreEqual(double.PositiveInfinity, a / b);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int a = int.MaxValue;
            // unless it is wrapped with "checked", it won't throw
            // checking for overflow every math operation would be a perf hit 
            Assert.ThrowsException<OverflowException>(() => checked(a++));
        }
    }

    public class SomeApi
    {
        public int Begin() => (int)ErrorCodes.Success;
        public int DoWork() => (int)ErrorCodes.Success;
        public int End() => (int)ErrorCodes.GeneralFailure;
    }


    public enum ErrorCodes : int
    {
        Success = 0,
        InvalidParameter = 1,
        NotFound = 2,
        GeneralFailure = 10,
        //...
    }

    public class Calculator
    {
        public double Div(double a, double b)
        {
            return a / b;
        }

        public int Div(double a, double b, out double result)
        {
            if (b == 0)
            {
                result = 0;
                return (int)ErrorCodes.InvalidParameter;
            }

            result = a / b;
            return (int)ErrorCodes.Success;
        }
    }

}
