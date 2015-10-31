namespace _09.First50MemebersOfSequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = 2;

            var queue = new Queue<int>();
            queue.Enqueue(n);

            Console.WriteLine("N = {0}", n);
            Console.Write("S =");

            var index = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(" {0}", current);
                index++;

                if (index == 50)
                {
                    Console.WriteLine();
                    return;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue((2 * current) + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
