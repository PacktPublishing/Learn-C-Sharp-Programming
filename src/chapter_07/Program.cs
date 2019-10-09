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
            numbers.Add(5);
            numbers.Add(7);
            numbers.Add(11);
            Console.WriteLine($"Size: {numbers.Count}");
            PrintCollection(numbers);

            var index = numbers.IndexOf(5);
            Console.WriteLine($"IndexOf(5): {index}");

            numbers.RemoveAt(index);
            Console.WriteLine($"Size: {numbers.Count}");
            PrintCollection(numbers);

            numbers.Insert(0, 13);
            Console.WriteLine($"Size: {numbers.Count}");
            PrintCollection(numbers);

            numbers.Sort();
            PrintCollection(numbers);

            numbers.Reverse();
            PrintCollection(numbers);
         }
      }

      static void Main(string[] args)
      {
         ListDemo();

         ListDemo lstDemo = new ListDemo();
         lstDemo.ShowListOperations();

         StackDemo stackDemo = new StackDemo();
         stackDemo.ShowStackOperations();

         QueueDemo queueDemo = new QueueDemo();
         queueDemo.ShowQueueOperations();

         LinkedListDemo linkedListDemo = new LinkedListDemo();
         linkedListDemo.ShowLinkedListOperations();

         DictionaryDemo dictionaryDemo = new DictionaryDemo();
         dictionaryDemo.ShowDictionaryOperations();

         HashSetDemo hashSetDemo = new HashSetDemo();
         hashSetDemo.ShowHashSetOperations();

         Console.ReadLine();
      }
   }
}
