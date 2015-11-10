namespace _09.FindLargestConnectedArea
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static char[,] lab =
        {
             { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
             { '*', '*', ' ', '*', ' ', '*', ' ' },
             { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
             { ' ', '*', '*', '*', '*', '*', ' ' },
             { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static int currentNeighbourCellsCount = 0;
        private static int maxNeighbourCellsCount = 0;

        public static void Main(string[] args)
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == '*')
                    {
                        continue;
                    }

                    currentNeighbourCellsCount = 0;
                    FindPath(row, col);

                    if (currentNeighbourCellsCount > maxNeighbourCellsCount)
                    {
                        maxNeighbourCellsCount = currentNeighbourCellsCount;
                    }
                }
            }

            Console.WriteLine(maxNeighbourCellsCount);
        }

        private static void FindPath(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 's';

            currentNeighbourCellsCount++;
            FindPath(row, col - 1);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);
        }

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}
