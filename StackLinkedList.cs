using System;
using System.Collections.Generic;
public class StackLinkedList
{
    internal class Node
    {
        internal Object value;

        internal Node next;

        public Node(Object value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(Object value, Node next)
        {
            this.value = value;
            this.next = next;
        }
    }

    private Node _head;
    private int _size;
    private List<Object> _items;

    public StackLinkedList()
    {
        _items = new List<object>();
        this._head = null;
        _size = 0;
    }

    public int Count { get { return this._size;} }

    public void Push(Object value)
    {
        var newNode = new Node(value, this._head);
        this._head = newNode;

        _items.Add(newNode);
        _size++;
    }

    public Object Pop()
    {
        if (_size == 0)
        {
            throw new Exception("no items to pop");
        }

        var tempNode = this._head;
        this._head = this._head.next;
        _items.Remove(tempNode);
        _size--;

        return tempNode;
    }

    public Object Peek()
    {
        if (_size == 0)
        {
            throw new Exception("no items to peek");
        }

        return this._head != null ? this._head.value : null;
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