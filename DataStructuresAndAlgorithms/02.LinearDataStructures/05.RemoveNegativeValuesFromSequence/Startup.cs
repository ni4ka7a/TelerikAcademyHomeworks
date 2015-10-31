namespace _05.RemoveNegativeValuesFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int>() { -4, 2, -2, 5, 2, -3, 2, -3, -1, 5, 2 };

            sequence = sequence
                .Where(x => x > 0)
                .ToList();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
