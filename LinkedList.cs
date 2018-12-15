using System.Collections.Generic;

public class LinkedList
{
    private class LinkNode
    {
        private object _value;

        private LinkNode _next;

        public LinkNode Next
        {
            get { return this._next; }
            set
            {
                this._next = value;
            }
        }

        public object Value
        {
            get { return this._value; }
        }

        public LinkNode(object value, LinkNode next)
        {
            this._value = value;
            this._next = next;
        }
    }

    private List<LinkNode> _items;
    private LinkNode _header;
    private LinkNode _tail;
    private int _length;

    public int Length
    {
        get { return this._length; }
    }

    public LinkedList(object item)
    {
        _items = new List<LinkNode>
        {
          new LinkNode(item, null)
        };
        this._header = _items[0];
        this._tail = _items[0];
        _length++;
    }

    public void Append(object value)
    {
        if (value == null) return;
        if (_items.Equals(null)) return; //throw exception

        var newNode = new LinkNode(value, null);
        _items.Add(newNode);
        this._tail.Next = newNode;
        this._tail = newNode;
        _length++;
    }

    public void Prepend(object value)
    {
        if (value == null) return;
        if (_items.Equals(null)) return; //throw exception

        var newNode = new LinkNode(value, null);
        newNode.Next = this._header;
        this._header = newNode;
        _items.Add(newNode);
        _length++;
    }

    public void Remove(object value)
    {
        if (value == null) return;
        if (_items.Equals(null)) return; //throw exception

        if (this._header.Value.Equals(value))
        {
            var tempNode = this._header.Next;
            _items.Remove(this._header);
            this._header = tempNode;
            
            return;
        }

        var currentNode = this._header;
        while (currentNode.Next != null) {
            if (currentNode.Next.Value.Equals(value))
            {
                var tempNode = currentNode.Next.Next;
                _items.Remove(currentNode.Next);
                currentNode.Next = tempNode;
                _length--;

                return;
            }
        }
    }

    public List<object> GetItems()
    {
        var items = new List<object>();
        var currentNode = this._header;
        while (currentNode != null) {
            items.Add(currentNode.Value);
            currentNode = (LinkNode)currentNode.Next;
        }

        return items;
    }
}