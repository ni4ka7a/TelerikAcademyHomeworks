namespace _13.QueueImplementation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            queue.Enqueue(6);
            queue.Enqueue(16);
            queue.Enqueue(71);
            queue.Enqueue(131);

            while (queue.Count > 0)
            {
                Console.Write("{0} ", queue.Dequeue());
            }

            Console.WriteLine();
        }
    }
}
