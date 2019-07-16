using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    public class GenericDemo<T>
    {
        T GenProp { get; set; }
        public GenericDemo(T genProp)
        {
            GenProp = genProp;
        }

        public void GetT()
        {
            Console.WriteLine("The value of T is " + GenProp);
            Console.WriteLine("The type of T is " + typeof(T));
        }
    }
}
