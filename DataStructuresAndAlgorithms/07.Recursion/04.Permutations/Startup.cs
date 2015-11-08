namespace _04.Permutations
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // Algorithm reference: https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/tree/master/08.%20Combinatorics
            var n = 3; // Console.ReadLine();

            var arr = FillArrayOfIntegers(n);

            GeneratePermutations(arr, 0);
        }

        private static int[] FillArrayOfIntegers(int n)
        {
            var arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            return arr;
        }

        private static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
