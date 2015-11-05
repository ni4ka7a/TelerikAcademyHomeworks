namespace _04.HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int DefaultCapacity = 16;
        private const float DefaultLoadFactor = 0.75f;

        private int currentCapacity;
        private int count;
        private int currentLoad;
        private LinkedList<KeyValuePair<K, T>>[] hashTable;

        public HashTable()
            : this(DefaultCapacity)
        {
        }

        public HashTable(int capacity)
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.currentCapacity = capacity;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.currentCapacity;
            }
        }

        public ICollection<T> Values
        {
            get
            {
                List<T> returnValues = new List<T>();
                foreach (LinkedList<KeyValuePair<K, T>> item in this.hashTable)
                {
                    if (item != null)
                    {
                        foreach (KeyValuePair<K, T> element in item)
                        {
                            returnValues.Add(element.Value);
                        }
                    }
                }

                return returnValues;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                List<K> returnKeys = new List<K>();
                foreach (LinkedList<KeyValuePair<K, T>> item in this.hashTable)
                {
                    if (item != null)
                    {
                        foreach (KeyValuePair<K, T> element in item)
                        {
                            returnKeys.Add(element.Key);
                        }
                    }
                }

                return returnKeys;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public void Add(K key, T value)
        {
            if (this.currentLoad > this.hashTable.Length * 0.75)
            {
                this.Resize();
            }

            int hashCode = this.GetHash(key);

            if (this.hashTable[hashCode] == null)
            {
                LinkedList<KeyValuePair<K, T>> newList = new LinkedList<KeyValuePair<K, T>>();
                newList.AddFirst(new KeyValuePair<K, T>(key, value));
                this.hashTable[hashCode] = newList;
                this.count++;
                this.currentLoad++;
            }
            else
            {
                foreach (var item in this.hashTable[hashCode])
                {
                    if (item.Key.Equals(key))
                    {
                        throw new Exception("Key is already in a HashTable:");
                    }
                }

                this.hashTable[hashCode].AddLast(new KeyValuePair<K, T>(key, value));
                this.count++;
            }
        }

        public T Find(K key)
        {
            if (this.hashTable[this.GetHash(key)] != null)
            {
                foreach (KeyValuePair<K, T> item in this.hashTable[this.GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new Exception("Key not exist.");
        }

        public bool ContainsKey(K key)
        {
            if (this.hashTable[this.GetHash(key)] != null)
            {
                foreach (KeyValuePair<K, T> item in this.hashTable[this.GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Remove(K key)
        {
            int hashCode = this.GetHash(key);

            if (this.hashTable[hashCode] == null)
            {
                return;
            }

            KeyValuePair<K, T> toRemovePair = new KeyValuePair<K, T>();

            foreach (KeyValuePair<K, T> item in this.hashTable[hashCode])
            {
                if (item.Key.Equals(key))
                {
                    toRemovePair = item;
                }
            }

            this.hashTable[hashCode].Remove(toRemovePair);

            this.count--;
        }

        public void Clear()
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[DefaultCapacity];
            this.count = 0;
            this.currentLoad = 0;
        }

        private void Resize()
        {
            this.currentCapacity *= 2;
            LinkedList<KeyValuePair<K, T>>[] oldHashTable = this.hashTable;
            LinkedList<KeyValuePair<K, T>>[] newHashTable = new LinkedList<KeyValuePair<K, T>>[this.currentCapacity];
            this.hashTable = newHashTable;
            this.count = 0;
            this.currentLoad = 0;

            foreach (LinkedList<KeyValuePair<K, T>> item in oldHashTable)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> element in item)
                    {
                        this.Add(element.Key, element.Value);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<K, T>> chain in this.hashTable)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, T> pair in chain)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private int GetHash(K key)
        {
            int hash = key.GetHashCode();
            if (hash < 0)
            {
                hash = -hash;
            }

            return hash % this.hashTable.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, T>>)this).GetEnumerator();
        }
    }
}