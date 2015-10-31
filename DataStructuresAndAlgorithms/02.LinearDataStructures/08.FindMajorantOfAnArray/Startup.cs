namespace _08.FindMajorantOfAnArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var occurrences = FindOccurrences(sequence);

            var potentialMajorant = occurrences.Max();

            if (potentialMajorant >= (sequence.Count / 2) + 1)
            {
                Console.WriteLine("The Majorant of the array is {0}", Array.FindIndex(occurrences, x => x == potentialMajorant));
            }
            else
            {
                Console.WriteLine("There is no Majorant in the array");
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
