namespace _01.SimulateNestedLoops
{
    using System;

    public class Startup
    {
        private static int[] arr;

        public static void Main(string[] args)
        {
            var n = 2; // Console.ReadLine();
            arr = new int[n];

            SimulateLoop(0, 1, n);
        }

        private static void SimulateLoop(int index, int start, int end)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                SimulateLoop(index + 1, start, end);
            }
        }
    }
}
