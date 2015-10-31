namespace _06.RemoveValuesThatOccurOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var occurrences = new int[sequence.Max() + 1];

            for (int i = 0; i < sequence.Count; i++)
            {
                var currentNumber = sequence[i];
                occurrences[currentNumber]++;
            }

            for (int i = 0; i < occurrences.Length; i++)
            {
                if (occurrences[i] % 2 != 0)
                {
                    sequence.RemoveAll(x => x == i);
                }
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
