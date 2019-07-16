using chapter_06.Interface;

namespace chapter_06
{
    class Student : IJoin<string>
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string Add()
        {
            return FirstName + " " + LastName;
        }
    }
}
