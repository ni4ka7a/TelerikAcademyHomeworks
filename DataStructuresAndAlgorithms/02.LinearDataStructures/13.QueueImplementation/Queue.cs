namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class Queue<T>
    {
        private LinkedList<T> values;

        public Queue()
        {
            this.values = new LinkedList<T>();
        }

        public int Count
        {
            get { return this.values.Count; }
        }

        public void Enqueue(T item)
        {
            this.values.AddLast(item);
        }

        public T Dequeue()
        {
            if (this.values.Count == 0)
            {
                throw new NullReferenceException("The queue is empty.");
            }

            var item = this.values.First.Value;
            this.values.RemoveFirst();

            return item;
        }

        public T Peek()
        {
            if (this.values.Count == 0)
            {
                throw new NullReferenceException("The queue is empty.");
            }

            return this.values.First.Value;
        }
    }
}
