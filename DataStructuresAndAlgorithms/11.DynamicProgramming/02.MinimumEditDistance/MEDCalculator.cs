namespace _02.MinimumEditDistance
{
    using System;

    public class MEDCalculator
    {
        private decimal deleteCost;
        private decimal insertCost;
        private decimal replaceCost;

        public MEDCalculator(decimal insertCost, decimal deleteCost, decimal replaceCost)
        {
            this.insertCost = insertCost;
            this.deleteCost = deleteCost;
            this.replaceCost = replaceCost;
        }

        public decimal Calculate(string target, string input)
        {
            var distance_table = new double[input.Length + 1, target.Length + 1];

            for (int k = 0; k <= input.Length; k++)
            {
                distance_table[k, 0] = k * 0.7;
            }

            for (int k = 0; k <= target.Length; k++)
            {
                distance_table[0, k] = k * 0.7;
            }

            for (int k = 1; k <= input.Length; k++)
            {
                for (int d = 1; d <= target.Length; d++)
                {
                    if (input[k - 1] == target[d - 1])
                    {
                        distance_table[k, d] = distance_table[k - 1, d - 1];
                    }
                    else
                    {
                        distance_table[k, d] = Math.Min(
                            Math.Min(distance_table[k - 1, d - 1] + 1, distance_table[k - 1, d] + 0.7), distance_table[k, d - 1] + 0.7);
                    }
                }
            }

            decimal totalCost = 0;
            int i = input.Length, j = target.Length;

            while (true)
            {
                if (i == 0 && j == 0)
                {
                    return totalCost;
                }
                else if (i == 0 && j > 0)
                {
                    totalCost += this.deleteCost;
                    j--;
                }
                else if (i > 0 && j == 0)
                {
                    totalCost += this.insertCost;
                    i--;
                }
                else
                {
                    if (distance_table[i - 1, j - 1] <= distance_table[i - 1, j] &&
                            distance_table[i - 1, j - 1] <= distance_table[i, j - 1])
                    {
                        if (distance_table[i - 1, j - 1] == distance_table[i, j])
                        {
                            totalCost += 0;
                        }
                        else
                        {
                            totalCost += this.replaceCost;
                        }

                        i--;
                        j--;
                    }
                    else if (distance_table[i - 1, j] < distance_table[i, j - 1])
                    {
                        totalCost += this.insertCost;
                        i--;
                    }
                    else if (distance_table[i, j - 1] < distance_table[i - 1, j])
                    {
                        totalCost += this.deleteCost;
                        j--;
                    }
                }
            }
        }
    }
}
