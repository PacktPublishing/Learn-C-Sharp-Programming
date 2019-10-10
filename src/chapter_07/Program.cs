using System;
using System.Collections.Generic;

namespace chapter_07
{
   class Program
   {
      static void PrintCollection<T>(IEnumerable<T> collection)
      {
         foreach (var e in collection)
            Console.Write($"{e} ");
         Console.WriteLine();
      }     

      static void ListDemo()
      {
         {
            var numbers = new List<int>();
            var words = new List<string>();
         }
         {
            var numbers = new List<int> { 1, 2, 3, 5, 7, 11 };
            var words = new List<string> { "one", "two" };

            PrintCollection(numbers);
            PrintCollection(words);
         }

         {
            var numbers = new List<int> { 1, 2, 3 };
            numbers.Add(5);       // 1  2  3  5
            numbers.AddRange(new int[] { 7, 11 });
                                  // 1  2  3  5  7 11
            numbers.Insert(5, 1); // 1  2  3  5  7  1 11
            numbers.Insert(5, 1); // 1  2  3  5  7  1  1 11
            numbers.InsertRange(1, new int[] { 13, 17, 19 });
                                  // 1 13 17 19  2  3  5  7  1  1 11

            Console.WriteLine($"Size: {numbers.Count}");
            PrintCollection(numbers);

            numbers.Remove(1);              // 13 17 19  2  3  5  7  1  1 11
            PrintCollection(numbers);

            numbers.RemoveRange(2, 3);      // 13 17  5  7  1  1 11
            PrintCollection(numbers);

            numbers.RemoveAll(e => e < 10); // 13 17 11
            PrintCollection(numbers);

            numbers.RemoveAt(1);            // 13 11
            PrintCollection(numbers);

            numbers.Clear();                // 
            PrintCollection(numbers);
         }

         {
            var numbers = new List<int> { 1, 2, 3, 5, 7, 11 };

            var a = numbers.Find(e => e < 10);     // 1
            var b = numbers.FindLast(e => e < 10); // 7
            var c = numbers.FindAll(e => e < 10);  // 1 2 3 5 7
         }

         {
            var numbers = new List<int> { 1, 1, 2, 3, 5, 8, 11 };

            var a = numbers.FindIndex(e => e < 10);     // 0
            var b = numbers.FindLastIndex(e => e < 10); // 5
            var c = numbers.IndexOf(5);                 // 4
            var d = numbers.LastIndexOf(1);             // 1
            var e = numbers.BinarySearch(8);            // 5
         }

         {
            var numbers = new List<int> { 1, 5, 3, 11, 8, 1, 2 };

            numbers.Sort();     // 1 1 2 3 5 8 11
            numbers.Reverse();  // 11 8 5 3 2 1 1
         }
      }

      static void StackDemo()
      {
         {
            var arr = new string[] { "Ankit", "Marius", "Raffaele" };
            Stack<string> names = new Stack<string>(arr);

            Stack<int> numbers = new Stack<int>();
         }

         {
            Stack<int> numbers = new Stack<int>(new int[]{ 1, 2, 3 });
            PrintCollection(numbers);  // 3 2 1

            numbers.Push(5);           // 5 3 2 1
            PrintCollection(numbers);

            numbers.Push(7);           // 7 5 3 2 1
            PrintCollection(numbers);

            numbers.Pop();             // 5 3 2 1
            PrintCollection(numbers);

            var n = numbers.Peek();    // 5 3 2 1
            PrintCollection(numbers);

            numbers.Push(11);          // 11 5 3 2 1
            PrintCollection(numbers);

            numbers.Clear();           // empty
            PrintCollection(numbers);
         }
      }

      static void QueueDemo()
      {
         {
            var arr = new string[] { "Ankit", "Marius", "Raffaele" };
            Queue<string> names = new Queue<string>(arr);

            Queue<int> numbers = new Queue<int>();
         }

         {
            Queue<int> numbers = new Queue<int>(new int[] { 1, 2, 3 });
            PrintCollection(numbers);  // 1 2 3

            numbers.Enqueue(5);        // 1 2 3 5
            PrintCollection(numbers);

            numbers.Enqueue(7);        // 1 2 3 5 7
            PrintCollection(numbers);

            numbers.Dequeue();         // 2 3 5 7
            PrintCollection(numbers);

            var n = numbers.Peek();    // 2 3 5 7
            PrintCollection(numbers);

            numbers.Enqueue(11);       // 2 3 5 7 11
            PrintCollection(numbers);

            numbers.Clear();           // empty
            PrintCollection(numbers);
         }
      }

      static void Main(string[] args)
      {
         //ListDemo();
         //StackDemo();
         QueueDemo();
      }
   }
}
