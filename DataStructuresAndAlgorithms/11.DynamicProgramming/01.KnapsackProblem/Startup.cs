namespace _01.KnapsackProblem
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // this algoithm only finds the highest cost

            var numberOfProducts = 6; //int.Parse(Console.ReadLine());
            var knapsackCapacity = 10; // int.Parse(Console.ReadLine());

            var weights = new int[] { 3, 8, 4, 1, 2, 8 };
            var costs = new int[] { 2, 12, 5, 4, 3, 13 };

            var result = Knapsack(knapsackCapacity, weights, costs, numberOfProducts);

            Console.WriteLine(result);

        }

        private static int Knapsack(int knapsackCapasity, int[] weights, int[] costs, int numberOfProducts)
        {
            var pairs = new int[numberOfProducts + 1, knapsackCapasity + 1];

            for (int i = 0; i <= numberOfProducts; i++)
            {
                for (int j = 0; j <= knapsackCapasity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        pairs[i, j] = 0;
                    }

                    else if (weights[i - 1] < j)
                    {
                        var firstValue = (costs[i - 1] + (pairs[i - 1, j - weights[i - 1]]));
                        var secondValue = pairs[i - 1, j];
                        pairs[i, j] = Math.Max(firstValue, secondValue);
                    }

                    else
                    {
                        pairs[i, j] = pairs[i - 1, j];
                    }
                }
            }

            var a = pairs.GetLength(0) - 1;
            var b = pairs.GetLength(1) - 1;
            return pairs[a, b];
        }
    }
}
