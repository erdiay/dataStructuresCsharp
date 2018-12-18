using System;
using System.Collections.Generic;
public class QueueWithStack
{
    private Stack _items;
    private Stack _swapedItems;
    private Object _head;

    public QueueWithStack()
    {
        _head = null;
        _items = new Stack();
        _swapedItems = new Stack();
    }

    public int Count { get {return _items.Count + _swapedItems.Count;} }

    public void Enqueue(Object value)
    {
        if (_items.Count == 0) {
            _head = value;
        }
        _items.Push(value);
    }

    public Object Dequeue() {
        if (_swapedItems.Count == 0)
        {
            while (_items.Count > 0)
            {
                _swapedItems.Push(_items.Pop());
            }
        }
        return _swapedItems.Pop();
    }

    public Object Peek()
    {
        if (_swapedItems.Count > 0)
        {
            return _swapedItems.Peek();
        }
        return _head;
    }
}