using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_15_09
{
    public struct Numbers
    {
        private int _i;

        public readonly int Num0
        {
            get => _i;
            set { } // not useful but valid
        }

        public readonly int Num1
        {
            get => _i;
            //set => _i = value; // not valid
        }

        public int Num2
        {
            readonly get => _i;
            set => _i = value; // ok
        }

        public int Num3
        {
            get => ++_i;     // strongly discouraged but it works
            readonly set { } // does not make sense but it works
        }

    }
}
