using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class KeyValueSet<K, V>
    {
        public K Key;
        public V Value;

        public KeyValueSet(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    public class HashTableLinkedList<K, V>
    {
        LinkedList<KeyValueSet<K, V>>[] hashTable;
        int modNumber = 17;
        int arraySize;

        public HashTableLinkedList(int size)
        {
            hashTable = new LinkedList<KeyValueSet<K, V>>[size];
            arraySize = size;
        }

        public LinkedList<KeyValueSet<K, V>>[] InternalDataStructure
        {
            get { return hashTable; }
        }

        public void Add(K key, V value)
        {
            int hashTableIndex = GetHashTableIndex(key);
            var currentLinkedList = hashTable[hashTableIndex];
            var newKeyValuePair = new KeyValueSet<K, V>(key, value);
            var newLinkedListNode = new LinkedListNode<KeyValueSet<K, V>>(newKeyValuePair);

            if (currentLinkedList == null)
            {
                currentLinkedList = new LinkedList<KeyValueSet<K, V>>();
                currentLinkedList.AddFirst(newLinkedListNode);
                hashTable[hashTableIndex] = currentLinkedList;
            }
            else
            {
                currentLinkedList.AddLast(newLinkedListNode);
            }
        }

        private int GetHashTableIndex(K Key)
        {
            return Math.Abs(Key.GetHashCode() % arraySize);
        }

        public void Remove(K key)
        {
            int hashTableIndex = GetHashTableIndex(key);

            var currentLinkedList = hashTable[hashTableIndex];
            if (currentLinkedList != null)
            {
                LinkedListNode<KeyValueSet<K, V>> currentNode = currentLinkedList.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        currentLinkedList.Remove(currentNode);
                        break;
                    }
                    currentNode = currentNode.Next;
                }
            }
            if (hashTable[hashTableIndex].Count == 0)
            {
                hashTable[hashTableIndex] = null;
            }
        }

    }
}
