namespace _01.PriorityQueueImplementation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var priorityQueue = new PriorityQueue<int>();

            priorityQueue.Add(1);
            priorityQueue.Add(2);
            priorityQueue.Add(513);
            priorityQueue.Add(51);
            priorityQueue.Add(1551);

            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
