namespace _01.CalculatePositiveNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = ReadInput();
            var sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine("The sum of the numbers is: {0}", sum);
            Console.WriteLine("The avarage of the numbers is: {0}", sum / numbers.Count);
        }

        private static IList<int> ReadInput()
        {
            Console.WriteLine("Enter a few numbers: (end with empty line)");
            var inputLine = Console.ReadLine();
            var numbers = new List<int>();

            while (inputLine != string.Empty)
            {
                try
                {
                    numbers.Add(int.Parse(inputLine));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number");
                }

                inputLine = Console.ReadLine();
            }

            return numbers;
        }
    }
}
