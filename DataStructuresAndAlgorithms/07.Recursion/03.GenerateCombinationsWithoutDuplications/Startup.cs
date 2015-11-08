namespace _03.GenerateCombinationsWithoutDuplications
{
    using System;

    public class Startup
    {
        private static int[] arr;

        public static void Main(string[] args)
        {
            var n = 4; // Console.ReadLine();
            var k = 2; // Console.ReadLine();

            arr = new int[k];
            GenerateCombinations(0, 1, n);
        }

        private static void GenerateCombinations(int index, int start, int end)
        {
            if (index == arr.Length)
            {
                Console.WriteLine("({0})", string.Join(", ", arr));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                GenerateCombinations(index + 1, i + 1, end);
            }
        }
    }
}
