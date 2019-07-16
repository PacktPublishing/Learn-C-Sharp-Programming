using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    class CompareObject
    {
        public bool Compare<T>(T input1, T input2)
        {
            return input1.Equals(input2);
        }
    }
}