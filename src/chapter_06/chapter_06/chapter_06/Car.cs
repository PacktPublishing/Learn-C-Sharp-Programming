using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    class Car : Vehicle
    {
        public override void PrintMessage()
        {
            Console.WriteLine("This vehicle is a car");
        }
    }
}
