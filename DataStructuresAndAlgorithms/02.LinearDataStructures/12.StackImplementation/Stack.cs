namespace _12.StackImplementation
{
    using System;

    public class Stack<T>
    {
        private T[] values;

        public Stack()
        {
            this.Count = 0;
            this.Capacity = 4;
            this.values = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            this.values[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if(this.Count == 0)
            {
                throw new NullReferenceException("The stack is empty");
            }

            this.Count--;
            return this.values[this.Count];
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("The stack is empty");
            }

            return this.values[this.Count];
        }

        private void Resize()
        {
            var newValues = new T[this.Capacity * 2];

            for (int i = 0; i < this.Capacity; i++)
            {
                newValues[i] = this.values[i];
            }

            this.Capacity = this.Capacity * 2;
            this.values = newValues;
        }
    }
}
