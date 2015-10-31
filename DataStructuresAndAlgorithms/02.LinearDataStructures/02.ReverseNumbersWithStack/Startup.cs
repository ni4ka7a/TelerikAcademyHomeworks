namespace _02.ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = ReadInput();

            Console.WriteLine("The reversed numbers are:\n");

            while (numbers.Count > 0)
            {
                Console.Write("{0} ", numbers.Pop());
            }

            Console.WriteLine();
        }

        private static Stack<int> ReadInput()
        {
            Console.WriteLine("Enter a few numbers: (end with empty line)");
            var inputLine = Console.ReadLine();
            var numbers = new Stack<int>();

            while (inputLine != string.Empty)
            {
                try
                {
                    numbers.Push(int.Parse(inputLine));
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
