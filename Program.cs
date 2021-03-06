﻿using System;

namespace dataStructuresCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedListTest();
            //HashtableTest();            
            //StackTest();
            //StackWithNodeTest();
            //QueueTest();
            //QueueLinkedListTest();
            //QueueWithStackTest();
            //BinarySearchTreeTest();
            AVLTreeTest();
        }

        internal static void AVLTreeTest()
        {
            var myAVLTree = new AVLTree();
            myAVLTree.Insert(30);
            myAVLTree.Insert(35);
            myAVLTree.Insert(5);
            myAVLTree.Insert(32);
            myAVLTree.Insert(40);
            myAVLTree.Insert(45);
        }
        internal static void BinarySearchTreeTest()
        {
            var myBST = new BinarySearchTree();
            // myBST.Insert(9);
            // myBST.Insert(4);
            // myBST.Insert(6);
            // myBST.Insert(20);
            // myBST.Insert(170);
            // myBST.Insert(15);
            // myBST.Insert(1);
            // myBST.Remove(20);

            myBST.Insert(41);
            myBST.Insert(20);
            myBST.Insert(11);
            myBST.Insert(29);
            myBST.Insert(32);
            myBST.Insert(65);
            myBST.Insert(50);
            myBST.Insert(91);
            myBST.Insert(72);
            myBST.Insert(99);
            myBST.Remove(41);


            Console.WriteLine(myBST.Lookup(170));
        }

        internal static void QueueWithStackTest()
        {
            var myQueue = new QueueWithStack();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            Console.WriteLine(myQueue.Peek());
            Console.WriteLine(myQueue.Dequeue());

        }

        internal static void QueueLinkedListTest()
        {
            var myQueue = new QueueLinkedList();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            foreach (var item in myQueue.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            myQueue.Enqueue(4);

            Console.WriteLine(myQueue.Dequeue());
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(90);
            myQueue.Enqueue(91);
            myQueue.Dequeue();
            foreach (var item in myQueue.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }

            //Console.WriteLine();
            //Console.WriteLine(myStack.Peek());
        }

        internal static void QueueTest()
        {
            var myQueue = new Queue();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            foreach (var item in myQueue.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            myQueue.Enqueue(4);

            Console.WriteLine(myQueue.Dequeue());
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            foreach (var item in myQueue.GetItems())
            {
                Console.Write(item.ToString() + " ");
            }

            //Console.WriteLine();
            //Console.WriteLine(myStack.Peek());
        }

        internal static void StackWithNodeTest()
        {
            var myStack = new StackLinkedList();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
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
            Console.WriteLine();
            Console.WriteLine(myStack.Peek());
        }

        internal static void StackTest()
        {
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

        internal static void HashtableTest()
        {
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

        internal static void LinkedListTest()
        {
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
