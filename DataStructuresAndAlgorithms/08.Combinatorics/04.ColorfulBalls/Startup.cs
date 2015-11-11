namespace _04.ColorfulBalls
{
    using System;

    public class Startup
    {
        private static int counter = 0;

        public static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().ToCharArray();
            Array.Sort(inputArr);
            PermuteRep(inputArr, 0, inputArr.Length);

            Console.WriteLine(counter);
        }


        static void PermuteRep(char[] arr, int start, int n)
        {
            counter++;

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}