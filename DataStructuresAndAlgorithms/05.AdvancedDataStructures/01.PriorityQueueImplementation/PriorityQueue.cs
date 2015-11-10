namespace _01.PriorityQueueImplementation
{
    using System;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private T[] data;
        private int currentIndex;
        private bool ascending;

        public PriorityQueue(int initalCapacity = InitialCapacity, bool ascending = true)
        {
            this.data = new T[initalCapacity];
            this.currentIndex = 0;
            this.ascending = ascending;
        }

        public PriorityQueue(bool ascending)
            : this(InitialCapacity, ascending)
        {
        }

        public int Count
        {
            get { return this.currentIndex; }
        }

        public void Add(T item)
        {
            this.data[this.currentIndex] = item;
            this.currentIndex++;
            this.UpdateOrder();
            this.UpdateSize();
        }

        public T Dequeue()
        {
            var topElement = this.data[0];

            this.data[0] = this.data[this.currentIndex - 1];
            this.currentIndex--;
            this.UpdateOrderFromTop();
            return topElement;
        }

        private void UpdateOrderFromTop(int index = 0)
        {
            var isChanged = false;

            var firstChildIndex = (index * 2) + 1;
            var secondChildIndex = firstChildIndex + 1;

            if (firstChildIndex >= this.currentIndex)
            {
                return;
            }

            if (!this.IsInOrder(this.data[index], this.data[firstChildIndex]))
            {
                this.SwapPositions(index, firstChildIndex);
                isChanged = true;
            }

            if (!this.IsInOrder(this.data[index], this.data[secondChildIndex]))
            {
                this.SwapPositions(index, secondChildIndex);
                isChanged = true;
            }

            if (isChanged)
            {
                this.UpdateOrderFromTop(firstChildIndex);
                this.UpdateOrderFromTop(secondChildIndex);
            }
        }

        private void UpdateSize()
        {
            if (this.currentIndex == this.data.Length)
            {
                this.DoubleSize();
            }
        }

        private void DoubleSize()
        {
            var doubleSizeData = new T[this.data.Length * 2];
            Array.Copy(this.data, doubleSizeData, this.data.Length);
            this.data = doubleSizeData;
        }

        private void UpdateOrder()
        {
            if (this.currentIndex == 1)
            {
                return;
            }

            var index = this.currentIndex - 1;

            while (true)
            {
                var parentIndex = (index - 1) / 2;

                if (!this.IsInOrder(this.data[parentIndex], this.data[index]))
                {
                    this.SwapPositions(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void SwapPositions(int first, int second)
        {
            var temp = this.data[first];
            this.data[first] = this.data[second];
            this.data[second] = temp;
        }

        private bool IsInOrder(T parent, T child)
        {
            var compare = parent.CompareTo(child);

            if (compare < 0)
            {
                return true == this.ascending; // this turns to false if is descending
            }
            else if (compare == 0)
            {
                return true;
            }

            return false == this.ascending; // turns to true if descending
        }
    }
}
