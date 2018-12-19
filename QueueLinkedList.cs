using System;
using System.Collections.Generic;
public class QueueLinkedList
{
    internal class Node
    {
        internal Object value;
        internal Node next;

        public Node(Object value)
        {
            this.value = value;
        }

        public Node(Object value, Node next)
        {
            this.value = value;
            this.next = next;
        }
    }

    private int _size;
    private Node _head;
    private Node _tail;
    private List<Node> _items;

    public QueueLinkedList()
    {
        _items = new List<Node>();
        _size = 0;
        _head = null;
        _tail = null;
    }

    public void Enqueue(Object value)
    {
        var newNode = new Node(value, null);
        if (_size == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.next = newNode;
            _tail = newNode;
        }

        _items.Add(newNode);
        _size++;
    }

    public Object Dequeue()
    {
        if (_size == 0)
        {
            throw new Exception("no items to dequeue");
        }

        var tempNode = _head;
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = tempNode.next;
        }
        _items.Remove(tempNode);
        _size--;

        return tempNode.value;
    }

    public List<Object> GetItems()
    {
        List<Object> tempItems = new List<object>();
        var node = this._head;
        while (node != null)
        {
            tempItems.Add(node.value);
            node = node.next;
        }

        return tempItems;
    }
}