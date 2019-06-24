using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_04
{
    class Student
    {
        private int[] StudentId = new int[5];
        public int this[int i]
        {
            get
            {
                return StudentId[i];
            }
            set
            {
                StudentId[i] = value;
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
    }
}
