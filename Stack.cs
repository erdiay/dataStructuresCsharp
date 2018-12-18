using System.Collections.Generic;
using System;
public class Stack
{
    private int _size;
    private const int _defaultCapacity = 10;
    private Object[] _items;

    public Stack()
    {
        _items = new Object[_defaultCapacity];
        _size = 0;
    }

    public Stack(Object value)
    {
        _items = new Object[_defaultCapacity];
        _size = 0;
        
        InternalInserToEmptyList(value);
    }

    internal void InternalInserToEmptyList(Object value) {
        _items[0] = value;
        _size++;
    }

    public int Count { get {return _size;} }

    public void Push(Object value)
    {
        if (_size == _items.Length)
        {
            //double the size
            Object[] newArray = new Object[_items.Length * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
        _items[_size++] = value;
    }

    public Object Pop()
    {
        if (_size == 0)
        {
            throw new Exception("no items to pop");
        }

        Object item = _items[--_size];
        _items[_size] = null;

        return item;
    }

    public Object Peek() {
        if (_size == 0)
        {
            throw new Exception("no items to peek");
        }

        return _items[_size - 1];
    }

    public List<Object> GetItems()
    {
        List<Object> tempItems = new List<object>();
        for (int i = 0; i < _size; i++)
        {
            tempItems.Add(_items[i]);
        }

        return tempItems;
    }
}