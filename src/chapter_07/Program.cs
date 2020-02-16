using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

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

      static void LinkedListDemo()
      {
         {
            var arr = new string[] { "Ankit", "Marius", "Raffaele" };
            var words = new LinkedList<string>(arr);
            var numbers = new LinkedList<int>();
         }

         {
            var numbers = new LinkedList<int>();
            var n2 = numbers.AddFirst(2);      // 2
            PrintCollection(numbers);

            var n1 = numbers.AddFirst(1);      // 1 2
            PrintCollection(numbers);

            var n7 = numbers.AddLast(7);       // 1 2 7
            PrintCollection(numbers);

            var n11 = numbers.AddLast(11);     // 1 2 7 11
            PrintCollection(numbers);

            var n3 = numbers.AddAfter(n2, 3);  // 1 2 3 7 11
            PrintCollection(numbers);

            var n5 = numbers.AddBefore(n7, 5); // 1 2 3 5 7 11
            PrintCollection(numbers);

            var fn1 = numbers.Find(5);
            var fn2 = numbers.FindLast(5);
            Console.WriteLine(fn1 == fn2);

            Console.WriteLine(numbers.Contains(3));
            Console.WriteLine(numbers.Contains(13));

            numbers.RemoveFirst();             // 2 3 5 7 11
            PrintCollection(numbers);

            numbers.RemoveLast();              // 2 3 5 7
            PrintCollection(numbers);

            numbers.Remove(3);                 // 2 5 7
            PrintCollection(numbers);

            numbers.Remove(n5);                // 2 7
            PrintCollection(numbers);

            numbers.Clear();                   // empty
            PrintCollection(numbers);
         }
      }

      static void DictionaryDemo()
      {
         {
            Dictionary<int, string> languages = new Dictionary<int, string>();
         }

         {
            Dictionary<int, string> languages = new Dictionary<int, string>()
            {
               {1, "C#"},
               {2, "Java"},
               {3, "Python"},
               {4, "C++"}
            };
         }

         {
            Dictionary<int, string> languages = new Dictionary<int, string>()
            {
               [1] = "C#",
               [2] = "Java",
               [3] = "Python",
               [4] = "C++"
            };
         }

         {
            Dictionary<int, string> languages = new Dictionary<int, string>()
            {
               {1, "C#"},
               {2, "Java"},
               {3, "Python"},
               {4, "C++"}
            };
            PrintCollection(languages);

            languages.Add(5, "JavaScript");
            PrintCollection(languages);

            languages.TryAdd(5, "JavaScript");
            PrintCollection(languages);

            languages[6] = "F#";
            PrintCollection(languages);

            languages[5] = "TypeScript";
            PrintCollection(languages);

            Console.WriteLine($"Has 5:  {languages.ContainsKey(5)}");
            Console.WriteLine($"Has C#: {languages.ContainsValue("C#")}");

            if (languages.TryGetValue(1, out string lang))
               Console.WriteLine(lang);
            else
               Console.WriteLine("Not found!");

            foreach (var kvp in languages)
            {
               Console.WriteLine($"[{kvp.Key}] = {kvp.Value}");
            }

            languages.Remove(5);
            PrintCollection(languages);

            languages.Clear();
            PrintCollection(languages);
         }
      }

      static void SetDemo()
      {
         {
            HashSet<int> numbers = new HashSet<int>();
         }

         {
            HashSet<int> numbers = new HashSet<int>()
            {
               1, 1, 2, 3, 5, 8, 11
            };
         }

         {
            HashSet<int> numbers = new HashSet<int>() { 11, 3, 8 };
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(5);
            PrintCollection(numbers);

            Console.WriteLine(numbers.Contains(1));
            Console.WriteLine(numbers.Contains(7));

            numbers.Remove(1);
            PrintCollection(numbers);

            numbers.RemoveWhere(n => n % 2 == 0);
            PrintCollection(numbers);

            numbers.Clear();
            PrintCollection(numbers);
         }

         {
            HashSet<int> a = new HashSet<int>() { 1, 2, 5, 6, 9};
            HashSet<int> b = new HashSet<int>() { 1, 2, 3, 4};

            var s1 = new HashSet<int>(a);
            s1.IntersectWith(b);
            PrintCollection(s1);

            var s2 = new HashSet<int>(a);
            s2.UnionWith(b);
            PrintCollection(s2);

            var s3 = new HashSet<int>(a);
            s3.ExceptWith(b);
            PrintCollection(s3);

            var s4 = new HashSet<int>(a);
            s4.SymmetricExceptWith(b);
            PrintCollection(s4);
         }

         {
            HashSet<int> a = new HashSet<int>() { 1, 2, 5, 6, 9 };
            HashSet<int> b = new HashSet<int>() { 1, 2, 3, 4 };
            HashSet<int> c = new HashSet<int>() { 2, 5 };

            Console.WriteLine(a.Overlaps(b));
            Console.WriteLine(a.IsSupersetOf(c));
            Console.WriteLine(c.IsSubsetOf(a));
         }
      }

      static async Task BlockingCollectionDemo()
      {
         using var bc = new BlockingCollection<int>();

         using var producer = Task.Run(() => {
            int a = 1, b = 1;
            bc.Add(a);
            bc.Add(b);
            for(int i = 0; i < 10; ++i)
            {
               int c = a + b;
               bc.Add(c);
               a = b;
               b = c;
            }
            bc.CompleteAdding();
         });
         
         using var consumer1 = Task.Run(() => { 
            try
            {
               while (true)
                  Console.WriteLine($"[1] {bc.Take()}");
            }
            catch (InvalidOperationException)
            {
               Console.WriteLine("[1] collection completed");
            }
            Console.WriteLine("[1] work done");
         });

         using var consumer2 = Task.Run(() => {
            foreach(var n in bc.GetConsumingEnumerable())
               Console.WriteLine($"[2] {n}");
            Console.WriteLine("[2] work done");
         });

         await Task.WhenAll(producer, consumer1, consumer2);
      }

      static void Main(string[] args)
      {
         ListDemo();
         StackDemo();
         QueueDemo();
         LinkedListDemo();
         DictionaryDemo();
         SetDemo();
         BlockingCollectionDemo().Wait();
      }
   }
}
