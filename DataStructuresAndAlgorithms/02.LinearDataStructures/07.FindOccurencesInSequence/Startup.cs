namespace _07.FindOccurencesInSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var occurences = FindOccurrences(sequence);

            for (int i = 0; i < occurences.Length; i++)
            {
                if (occurences[i] != 0)
                {
                    Console.WriteLine("{0} => {1} times", i, occurences[i]);
                }
            }
        }

        private static int[] FindOccurrences(List<int> sequence)
        {
            var occurrences = new int[sequence.Max() + 1];

            foreach (var number in sequence)
            {
                occurrences[number]++;
            }

            return occurrences;
        }
    }
}
