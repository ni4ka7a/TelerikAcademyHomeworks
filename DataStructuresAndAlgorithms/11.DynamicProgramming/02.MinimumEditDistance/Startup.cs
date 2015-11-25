namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var medCalculator = new MEDCalculator(1, 0.9m, 0.8m);

            var input = new List<string[]>();
            input.Add(new string[] { "developer", "enveloped" });
            input.Add(new string[] { "developer", "eveloper" });
            input.Add(new string[] { "eveloper", "enveloper" });
            input.Add(new string[] { "r", "d" });

            foreach (var pair in input)
            {
                Console.WriteLine("{0, -10} | {1, -10} | {2}", pair[0], pair[1], medCalculator.Calculate(pair[0], pair[1]));
            }
        }
    }
}
