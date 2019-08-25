using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class DictionaryDemo
    {
        Dictionary<int, string> EmployeeDirectory { get; set; }

        public DictionaryDemo()
        {
            EmployeeDirectory = new Dictionary<int, string>();
        }

        public void ShowDictionaryOperations()
        {
            EmployeeDirectory.Add(101, "John");
            EmployeeDirectory.Add(102, "Mark");
            EmployeeDirectory.Add(103, "Katy");
            EmployeeDirectory.Add(104, "John");
            EmployeeDirectory.Add(105, "Harry");

            Console.WriteLine("Initial count of EmployeeDirectory is :" + EmployeeDirectory.Count);

            Console.WriteLine("Initial items in EmployeeDirectory are :");
            PrintDictionary(EmployeeDirectory);

            Console.WriteLine("The employee with id 103 is :" + EmployeeDirectory[103]);

            EmployeeDirectory[104] = "Ron";
            EmployeeDirectory[106] = "Emma";
            PrintDictionary(EmployeeDirectory);

            Console.WriteLine(EmployeeDirectory.ContainsKey(123));
            Console.WriteLine(EmployeeDirectory.ContainsValue("Harry"));

            Dictionary<int, string>.KeyCollection employeeId = EmployeeDirectory.Keys;

            foreach (int id in employeeId)
            {
                Console.WriteLine("Employee Id = {0}", id);
            }

            Dictionary<int, string>.ValueCollection employeeName = EmployeeDirectory.Values;

            foreach (string name in employeeName)
            {
                Console.WriteLine("Employee Name = {0}", name);
            }

            EmployeeDirectory.Remove(104);
            Console.WriteLine("Employee directory after removing the key 104");
            PrintDictionary(EmployeeDirectory);

            EmployeeDirectory.Clear();
        }

        void PrintDictionary(Dictionary<int, string> employeeDirectory)
        {
            foreach (KeyValuePair<int, string> employee in employeeDirectory)
            {
                Console.WriteLine("Employee ID = {0}, Employee Name = {1}", employee.Key, employee.Value);
            }
        }
    }
}
