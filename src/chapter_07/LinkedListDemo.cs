using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_07
{
    class LinkedListDemo
    {
        LinkedList<string> EmployeeName { get; set; }
        public void ShowLinkedListOperations()
        {
            string[] names = { "Mark", "Harry", "John", "Katy", "Ron" };

            EmployeeName = new LinkedList<string>(names);

            Console.WriteLine("The initial count of nodes in linked list is :" + EmployeeName.Count);

            Console.WriteLine("Initial items in the linked list are:");
            PrintLinkedList(EmployeeName);

            EmployeeName.RemoveFirst();
            Console.WriteLine("Linked list after removing the first node");
            PrintLinkedList(EmployeeName);

            EmployeeName.RemoveLast();
            Console.WriteLine("Linked list after removing the last node");
            PrintLinkedList(EmployeeName);

            EmployeeName.Remove("John");
            Console.WriteLine("Linked list after removing John");
            PrintLinkedList(EmployeeName);

            EmployeeName.AddFirst("Mark");
            Console.WriteLine("Linked list after adding an item at the beginning");
            PrintLinkedList(EmployeeName);

            EmployeeName.AddLast("Ron");
            Console.WriteLine("Linked list after adding an item at the end");
            PrintLinkedList(EmployeeName);

            LinkedListNode<string> currentNode = EmployeeName.Find("Harry");
            EmployeeName.AddAfter(currentNode, "John");
            Console.WriteLine("Linked list after adding John after Harry");
            PrintLinkedList(EmployeeName);

            EmployeeName.AddBefore(currentNode, "Emma");
            Console.WriteLine("linked list after adding Emma before Harry");
            PrintLinkedList(EmployeeName);

            Console.WriteLine(EmployeeName.Contains("Emma")); // return boolean

            EmployeeName.Clear();
        }

        void PrintLinkedList(LinkedList<string> employeeName)
        {
            foreach (string employee in employeeName)
            {
                Console.Write($" {employee}");
            }
            Console.WriteLine();
        }
    }
}
