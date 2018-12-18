﻿using System;

namespace dataStructuresCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedListTest();
            //HashtableTest();            
            StackTest();
        }

        internal static void StackTest() {
            var myStack = new Stack(4);
            myStack.Push(1);
            myStack.Push(5);
            foreach (var item in myStack.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();

            myStack.Pop();
            foreach (var item in myStack.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }
        }

        internal static void HashtableTest() {
            var myHashtable = new Hashtable<string, int>();
            myHashtable.Add("item1", 3);
            myHashtable.Add("item2", 1);
            myHashtable.Add("item3", 4);
            myHashtable.Add("item4", 5);
            myHashtable.Add("item5", 6);
            myHashtable.Remove("item3");
            Console.WriteLine(myHashtable.Get("item4"));
            Console.WriteLine(myHashtable.Get("item3"));

            var keys = myHashtable.GetKeys();
            foreach (var item in keys)
            {
                Console.Write(item.ToString() + " ");
            }
        }

        internal static void LinkedListTest() {
            var myLinkedList = new LinkedList<int>(5);
            myLinkedList.ReverseOrder();
            
            myLinkedList.Append(1);
            myLinkedList.Prepend(0);
            myLinkedList.Append(4);

            var items = myLinkedList.GetItems();
            foreach (var item in items)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();

            myLinkedList.Remove(0);
            myLinkedList.InsertAfter(5, 9);
            items = myLinkedList.GetItems();
            foreach (var item in items)
            {
                Console.Write(item.ToString() + " ");
            }
            
            Console.WriteLine();
            myLinkedList.ReverseOrder();
            items = myLinkedList.GetItems();
            foreach (var item in items)
            {
                Console.Write(item.ToString() + " ");
            }
        }
    }
}
