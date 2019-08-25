using System;

namespace chapter_07
{
    class Program
    {
        static void Main(string[] args)
        {
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
