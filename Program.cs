using System;

namespace dataStructuresCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListTest();
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
