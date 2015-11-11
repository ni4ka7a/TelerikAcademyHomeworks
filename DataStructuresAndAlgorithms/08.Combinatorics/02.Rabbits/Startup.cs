namespace _02.Rabbits
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inputRabitts = int.Parse(Console.ReadLine());
            var uniqueRabbits = new Dictionary<ulong, ulong>();

            for (int i = 0; i < inputRabitts; i++)
            {
                ulong currentNumber = ulong.Parse(Console.ReadLine());

                if (!uniqueRabbits.ContainsKey(currentNumber))
                {
                    uniqueRabbits[currentNumber] = 0;
                }

                uniqueRabbits[currentNumber]++;
            }

            ulong sum = 0;

            foreach (var item in uniqueRabbits)
            {
                if (item.Value > item.Key + 1)
                {
                    var magicNumber = item.Value / (item.Key + 1);

                    if (item.Value % (item.Key + 1) != 0)
                    {
                        magicNumber += 1;
                    }

                    sum += magicNumber * (item.Key + 1);
                }
                else
                {
                    sum += item.Key + 1;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
