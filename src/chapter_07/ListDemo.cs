using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class ListDemo
    {
        List<int> LstPrime { get; set; }
        public ListDemo()
        {
            LstPrime = new List<int>();
        }
        public void ShowListOperations()
        {
            LstPrime.Add(2);
            LstPrime.Add(3);
            LstPrime.Add(5);
            LstPrime.Add(7);
            LstPrime.Add(11);

            Console.WriteLine("The initial size of list is :" + LstPrime.Count);

            Console.WriteLine("Initial items in the list are");
            PrintList(LstPrime);

            Console.WriteLine("The index of item 5 is :" + LstPrime.IndexOf(5)); // return -1 if item is not found.

            Console.WriteLine("List items after removing the item 5");
            LstPrime.Remove(5);
            PrintList(LstPrime);

            LstPrime.RemoveAt(2);
            Console.WriteLine("List items after removing the item at index 2");
            PrintList(LstPrime);

            LstPrime.Insert(2, 7);
            Console.WriteLine("List items after inserting an item at index 2");
            PrintList(LstPrime);

            LstPrime.Reverse();
            Console.WriteLine("List item after reversing the list");
            PrintList(LstPrime);

            LstPrime.Sort();
            Console.WriteLine("List items after sorting the list");
            PrintList(LstPrime);

            Console.WriteLine(LstPrime.Contains(8)); // return boolean

            LstPrime.Clear();
        }

        static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }
    }
}
