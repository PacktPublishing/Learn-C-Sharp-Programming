using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_04.ClassType
{
    partial class PartialClassExample : Vehicle
    {
        public string Name { get; set; }

        public PartialClassExample()
        {
            this.id = 3;
        }
    }

    abstract class Vehicle
    {
        public int id;
    }
}
