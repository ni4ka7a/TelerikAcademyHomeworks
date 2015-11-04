namespace _01.CountOccurrences
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var occurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number] += 1;
                }
                else
                {
                    occurrences.Add(number, 1);
                }
            }

            foreach (var pair in occurrences)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
        }
    }
}
