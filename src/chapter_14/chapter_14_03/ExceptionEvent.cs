using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_14_03
{
    public class ExceptionEvent
    {
        public void TestMethod1()
        {
            A();
        }

        private void A() => B();

        private void B()
        {
            try
            {
                C();
            }
            catch (Exception err)
            {
                throw new Exception("B Exception");
            }
        }

        private void C()
        {
            try
            {
                D();
            }
            catch (Exception err)
            {
                throw new Exception("C Exception", err);
            }
        }

        private void D()
        {
            try
            {
                Crash();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Crash() => throw new Exception("Crashing");
    }
}
