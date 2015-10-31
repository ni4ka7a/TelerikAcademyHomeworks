namespace _10.OperationsInSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = 5;
            var m = 16;

            var sequence = FindTheShortestSequence(n, m).Reverse();

            foreach (var item in sequence)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static Queue<int> FindTheShortestSequence(int start, int end)
        {
            var operations = new Queue<int>();

            while (start <= end)
            {
                operations.Enqueue(end);

                if ((end % 2) == 0 && end / 2 >= start)
                {
                    end /= 2;
                }
                else if (end - 2 >= start)
                {
                    end -= 2;
                }
                else
                {
                    end -= 1;
                }
            }

            return operations;
        }
    }
}
