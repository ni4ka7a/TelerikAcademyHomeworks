namespace _01.SimulateNestedLoops
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = 2;
            SimulateLoop(1, 1, n);
        }

        private static void SimulateLoop(int i, int j, int n)
        {
            Console.WriteLine("{0} {1}", i, j);

            if (j >= n)
            {
                return;
            }

            SimulateLoop(i, j + 1, n);

            if (i >= n)
            {
                return;
            }

            SimulateLoop(i + 1, j, n);
        }
    }
}
