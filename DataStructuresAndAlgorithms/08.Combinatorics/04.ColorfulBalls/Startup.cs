namespace _04.ColorfulBalls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().ToCharArray();

            var letters = new Dictionary<char, int>();

            foreach (var item in inputArr)
            {
                if (!letters.ContainsKey(item))
                {
                    letters[item] = 0;
                }

                letters[item]++;
            }

            BigInteger down = 1;
            BigInteger up = Factuial(inputArr.Length);

            foreach (var item in letters)
            {
                down *= Factuial(item.Value);
            }

            Console.WriteLine(up / down);
        }

        private static BigInteger Factuial(int n)
        {
            BigInteger result = n;

            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }

            return result;
        }
    }
}