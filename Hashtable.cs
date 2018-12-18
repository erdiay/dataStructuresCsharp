using System.Collections.Generic;
using System.Collections;
using System;

internal class HashNode<K, V>
{
    internal K key;
    internal V value;
    internal HashNode<K, V> next;
    public HashNode(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}
public class Hashtable<K, V>
{
    private int size;
    private int numBuckets = 3;
    private List<HashNode<K, V>> bucketList;

    public Hashtable()
    {
        size = 0;
        bucketList = new List<HashNode<K, V>>();
        for (int i = 0; i < numBuckets; i++)
        {
            bucketList.Add(null);
        }
    }

    private int getBucketIndex(K key)
    {
        var hashCode = key.GetHashCode();
        return Math.Abs(hashCode % numBuckets);
    }

    public void Add(K key, V value)
    {
        var bucketIndex = getBucketIndex(key);
        var head = bucketList[bucketIndex];

        if (head != null)
        {
            var currentNode = head;
            do
            {
                if (currentNode.key.Equals(key))
                {
                    throw new Exception("key already exists");
                }
                currentNode = currentNode.next;
            } while (currentNode != null);
        }

        size++;
        var newNode = new HashNode<K, V>(key, value);
        newNode.next = head;
        bucketList[bucketIndex] = newNode;

        //If load factor goes beyond, then double hash table size
        if ((1.0 * size) / numBuckets >= 0.7)
        {
            var tempList = bucketList;
            numBuckets = 2 * numBuckets;
            bucketList = new List<HashNode<K, V>>();
            size = 0;
            for (int i = 0; i < numBuckets; i++)
            {
                bucketList.Add(null);
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                var node = tempList[i];
                while (node != null)
                {
                    Add(node.key, node.value);
                    node = node.next;
                }
            }

        }
    }

    public void Remove(K key)
    {
        if (key == null)
        {
            throw new Exception("key to be removed cannot be null");
        }

        var bucketIndex = getBucketIndex(key);
        var head = bucketList[bucketIndex];
        HashNode<K, V> prev = null;
        while (head != null)
        {
            if (head.key.Equals(key))
            {
                break;
            }

            prev = head;
            head = head.next;
        }

        if (head == null)
        {
            return;
        }

        if (prev != null)
        {
            prev.next = head.next;
        }
        else
        {
            bucketList[bucketIndex] = head.next;
        }
        bucketList.Remove(head);
        size--;
    }

    public V Get(K key)
    {
        if (key == null)
        {
            throw new Exception("key to be removed cannot be null");
        }

        var bucketIndex = getBucketIndex(key);
        var head = bucketList[bucketIndex];
        while (head != null)
        {
            if (head.key.Equals(key))
            {
                return head.value;
            }
            head = head.next;
        }

        //returns 0 for integers and may cause an error. 
        //maybe object type is more suitable for hashtables, not the generics.
        return default;
    }

    public List<K> GetKeys()
    {
        List<K> keys = new List<K>();
        for (int i = 0; i < bucketList.Count; i++)
        {
            var head = bucketList[i];
            while (head != null)
            {
                keys.Add(head.key);
                head = head.next;
            }
        }

        return keys;
    }

}