namespace _03.SortSequenceOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = ReadInput();

            numbers.Sort();

            Console.WriteLine("The sorted numbers are:");
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static List<int> ReadInput()
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
