using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class HashSetDemo
    {
        HashSet<int> OddNumbers { get; set; }
        HashSet<int> PrimeNumbers { get; set; }

        public HashSetDemo()
        {
            OddNumbers = new HashSet<int>();
            PrimeNumbers = new HashSet<int>();

            HashSet<string> names = new HashSet<string>();
        }

        public void ShowHashSetOperations()
        {
            OddNumbers.Add(1);
            OddNumbers.Add(3);
            OddNumbers.Add(5);
            OddNumbers.Add(7);
            OddNumbers.Add(9);

            PrimeNumbers.Add(2);
            PrimeNumbers.Add(3);
            PrimeNumbers.Add(5);
            PrimeNumbers.Add(7);

            Console.WriteLine("Count of item in set of odd numbers :" + OddNumbers.Count);

            Console.WriteLine("Does the set OddNumbers contains the item 9: " + OddNumbers.Contains(9));

            HashSet<int> unionSet = new HashSet<int>(OddNumbers);
            unionSet.UnionWith(PrimeNumbers);
            Console.WriteLine("Union of set PrimeNumbers and OddNumbers is ");
            PrintSet(unionSet);

            HashSet<int> intersectSet = new HashSet<int>(OddNumbers);
            intersectSet.IntersectWith(PrimeNumbers);
            Console.WriteLine("Intersection of set PrimeNumbers and OddNumbers is ");
            PrintSet(intersectSet);

            PrimeNumbers.Remove(2);

            Console.WriteLine("Does the set PrimeNumbers is a subset of set OddNumbers: " + PrimeNumbers.IsSubsetOf(OddNumbers));
            Console.WriteLine("Does the set OddNumbers is a superset of set PrimeNumbers: " + OddNumbers.IsSupersetOf(PrimeNumbers));

            PrimeNumbers.Clear();
        }

        void PrintSet(HashSet<int> set)
        {
            foreach (int number in set)
            {
                Console.Write($" {number}");
            }
            Console.WriteLine();
        }
    }
}
