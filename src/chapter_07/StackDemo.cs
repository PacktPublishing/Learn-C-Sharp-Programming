using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class StackDemo
    {
        Stack<string> MovieStack { get; set; }

        public StackDemo()
        {
            MovieStack = new Stack<string>();
        }

        public void ShowStackOperations()
        {
            MovieStack.Push("Avengers");
            MovieStack.Push("Avatar");
            MovieStack.Push("Titanic");
            MovieStack.Push("Frozen");
            MovieStack.Push("Aquaman");

            Console.WriteLine("The initial size of stack is :" + MovieStack.Count);

            Console.WriteLine("Initial items in the stack are:");
            PrintStack(MovieStack);

            Console.WriteLine("Popping '{0}'", MovieStack.Pop());
            Console.WriteLine("Items in stack after popping one item:");
            PrintStack(MovieStack);

            Console.WriteLine("Next item to remove :{0}", MovieStack.Peek());

            Console.WriteLine(MovieStack.Contains("Titanic")); // return boolean

            MovieStack.Clear();
        }

        void PrintStack(Stack<string> stack)
        {
            foreach (string str in stack)
            {
                Console.Write($" {str}");
            }
            Console.WriteLine();
        }
    }
}
