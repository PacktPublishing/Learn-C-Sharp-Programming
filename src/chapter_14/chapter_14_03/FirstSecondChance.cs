using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_14_03
{
    public class FirstSecondChance
    {
        public void TestMethod1()
        {
            Crash1();
        }

        private void Crash1() => throw new Exception("This will make the app crash");


        public void TestMethod2() => Crash2(null);

        private void Crash2(string str) => Console.WriteLine(str.Length);

        public void TestMethod3()
        {
            try
            {
                // Open the Exception Settings (Ctrl-Alt-E)
                // Experiment by checking/unchecking "System.Exception" and re-run this code
                Crash1();
            }
            catch (Exception)
            {
            }
        }

    }
}
