namespace _06.GenerateVariationsWithoutRepetitions
{
    using System;

    public class Startup
    {
        private static string[] inputValues = new string[] { "test", "rock", "fun" };

        public static void Main(string[] args)
        {
            var k = 2; // Console.ReadLine();
            int[] arr = new int[k];

            GenerateVariationsNoRepetitions(0, k, arr);
        }

        private static void GenerateVariationsNoRepetitions(int index, int k, int[] arr)
        {
            if (k == 0)
            {
                Print(arr);
            }
            else
            {
                for (int i = index; i < inputValues.Length; i++)
                {
                    arr[k - 1] = i;
                    GenerateVariationsNoRepetitions(i + 1, k - 1, arr);
                }
            }
        }

        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(inputValues[arr[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
