namespace _05.GenerateVariations
{
    using System;

    public class Startup
    {
        private static string[] inputValues = new string[] { "hi", "a", "b" };

        public static void Main(string[] args)
        {
            // Algorithm reference: https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/tree/master/08.%20Combinatorics/demos
            var k = 2; // Console.ReadLine();
            int[] arr = new int[k];
            GenerateVariationsWithRepetitions(0, k, arr);
        }

        private static void GenerateVariationsWithRepetitions(int index, int k, int[] arr)
        {
            if (index >= k)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i < inputValues.Length; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1, k, arr);
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
