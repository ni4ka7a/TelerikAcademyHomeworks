namespace _02.ExtractOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inputSequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var occurrences = new Dictionary<string, int>();

            foreach (var str in inputSequence)
            {
                if (occurrences.ContainsKey(str))
                {
                    occurrences[str] += 1;
                }
                else
                {
                    occurrences.Add(str, 1);
                }
            }

            foreach (var pair in occurrences)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
                }
            }
        }
    }
}
