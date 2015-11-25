namespace Tribonacci
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int[] input;

        public static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Tribonacci(input[3]));
        }

        private static int Tribonacci(int n)
        {
            if (n == 1)
            {
                return input[0];
            }
            else if (n == 2)
            {
                return input[1];
            }
            else if (n == 3)
            {
                return input[2];
            }

            return Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
        }
    }
}
