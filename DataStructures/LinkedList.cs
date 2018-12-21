using System;
using System.Collections.Generic;

namespace dataStructuresCsharp
{
    public class LinkedList<T>
    {
        internal class LinkNode<T>
        {
            private T value;

            internal LinkNode<T> next;
            internal LinkNode<T> prev;

            public LinkNode<T> Next
            {
                get { return this.next; ; }
            }

            public LinkNode<T> Previous
            {
                get { return this.prev; }
            }

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public LinkNode(T value)
            {
                this.value = value;
            }

            public LinkNode(T value, LinkNode<T> next, LinkNode<T> prev)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;
            }
        }

        internal List<LinkNode<T>> items;
        internal LinkNode<T> head;
        internal LinkNode<T> tail;
        internal int count;

        public int Count
        {
            get { return this.count; }
        }

        public LinkedList()
        {
            items = new List<LinkNode<T>>();
        }

        public LinkedList(T value)
        {
            items = new List<LinkNode<T>>();

            var node = new LinkNode<T>(value);
            InternalInsertNodeToEmptyList(node);
        }

        private void InternalInsertNodeToEmptyList(LinkNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            tail = newNode;
            items.Add(newNode);
            count++;
        }

        private void InternalInsertNodeAfter(LinkNode<T> node, LinkNode<T> newNode)
        {
            newNode.next = node.next;
            newNode.prev = node;

            node.next.prev = newNode;
            node.next = newNode;

            if (node == tail)
            {
                tail = newNode;
            }

            items.Add(newNode);
            count++;
        }

        private void InternalInsertNodeBefore(LinkNode<T> node, LinkNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;

            node.prev.next = newNode;
            node.prev = newNode;

            if (node == head)
            {
                head = newNode;
            }

            items.Add(newNode);
            count++;
        }

        private void InternalRemoveNode(LinkNode<T> node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;

            if (node == head)
            {
                head = node.next;
            }
            else if (node == tail)
            {
                tail = node.prev;
            }

            items.Remove(node);
            count--;
        }

        internal void ValidateNewNode(LinkNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
        }

        public void Append(T value)
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var newNode = new LinkNode<T>(value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeAfter(tail, newNode);
            }
        }

        public void Prepend(T value)
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var newNode = new LinkNode<T>(value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeBefore(head, newNode);
            }
        }

        internal LinkNode<T> Find(T value)
        {
            LinkNode<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(value, node.Value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
                else
                {
                    do
                    {
                        if (node.Value == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
            }
            return null;
        }

        public void Remove(T value)
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var node = Find(value);
            if (node != null)
            {
                InternalRemoveNode(node);
            }
        }

        public void InsertAfter(T value, T valueToBeInserted)
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var node = Find(value);
            var newNode = new LinkNode<T>(valueToBeInserted);
            if (node != null)
            {
                InternalInsertNodeAfter(node, newNode);
            }
        }

        public bool Search(T value)
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var node = Find(value);
            if (node != null)
            {
                return true;
            }

            return false;
        }

        public void ReverseOrder()
        {
            if (items.Equals(null))
            {
                throw new ArgumentNullException("items");
            }

            var node = this.head;
            do
            {
                var tempNode = node.prev;

                node.prev = node.next;
                node.next = tempNode;
                node = node.prev;
            } while (node != head);
            var tempTail = tail;
            tail = head;
            head = tempTail;
        }

        public List<T> GetItems()
        {
            var items = new List<T>();
            var currentNode = this.head;
            do
            {
                items.Add(currentNode.Value);
                currentNode = currentNode.Next;
            } while (currentNode != head);

            return items;
        }
    }
}