using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class QueueDemo
    {
        Queue<string> MovieQueue { get; set; }

        public QueueDemo()
        {
            MovieQueue = new Queue<string>();
        }

        public void ShowQueueOperations()
        {
            MovieQueue.Enqueue("Avengers");
            MovieQueue.Enqueue("Avatar");
            MovieQueue.Enqueue("Titanic");
            MovieQueue.Enqueue("Frozen");
            MovieQueue.Enqueue("Aquaman");

            Console.WriteLine("The initial size of queue is :" + MovieQueue.Count);

            Console.WriteLine("Initial items in the queue are:");
            PrintQueue(MovieQueue);

            Console.WriteLine("Dequeuing  '{0}'", MovieQueue.Dequeue());
            Console.WriteLine("Items in queue after dequeuing one item:");
            PrintQueue(MovieQueue);

            Console.WriteLine("Next item to dequeue :{0}", MovieQueue.Peek());

            Console.WriteLine(MovieQueue.Contains("Titanic")); // return boolean

            MovieQueue.Clear();
        }

        void PrintQueue(Queue<string> queue)
        {
            foreach (string str in queue)
            {
                Console.Write($" {str}");
            }
            Console.WriteLine();
        }
    }
}
