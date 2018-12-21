using System;
using System.Collections.Generic;
using System.Linq;

namespace dataStructuresCsharp
{
    public class Queue
    {
        private int _size;
        private int _head;
        private int _tail;
        private Object[] _items;
        private const int _defaultCapacity = 3;

        public Queue()
        {
            _items = new Object[_defaultCapacity];
            _head = 0;
            _tail = 0;
        }

        private void Resize(int capacity)
        {
            var tempArray = new Object[capacity];
            if (_tail > _size)
            {
                Array.Copy(_items, _head, tempArray, 0, _size);
            }
            else
            {
                Array.Copy(_items, _head, tempArray, 0, _items.Length - _head);
                Array.Copy(_items, 0, tempArray, _items.Length - _head, _tail);
            }
            _items = tempArray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }

        public void Enqueue(Object value)
        {
            if (_size == _items.Length)
            {
                //double the capacity
                Resize(_items.Length * 2);
            }
            _items[_tail] = value;
            _tail = (_tail + 1) % _items.Length;
            _size++;
        }

        public Object Dequeue()
        {
            if (_items.Length == 0)
            {
                throw new Exception("no items to dequeue");
            }
            var item = _items[_head];
            _items[_head] = null;
            _head = (_head + 1) % _items.Length;
            _size--;

            return item;
        }

        public List<Object> GetItems()
        {
            var tempArray = new Object[_size];
            if (_size == 0) return tempArray.ToList();

            if (_tail > _head)
            {
                Array.Copy(_items, _head, tempArray, 0, _size);
            }
            else
            {
                Array.Copy(_items, _head, tempArray, 0, _items.Length - _head);
                Array.Copy(_items, 0, tempArray, _items.Length - _head, _tail);
            }

            return tempArray.ToList();
        }
    }
}