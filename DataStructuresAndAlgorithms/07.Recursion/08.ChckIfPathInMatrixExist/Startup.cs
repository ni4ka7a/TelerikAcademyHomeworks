namespace _08.ChckIfPathInMatrixExist
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static char[,] lab = GenerateBigMatix(100);

        private static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();

        public static void Main(string[] args)
        {
            // IF You may get a stack overflow exception decrease the size of the matrix
            // by passing lower number to GenerateBigMatix() method
            FindPath(0, 0);
        }

        private static void FindPath(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Path exists!");
                Environment.Exit(0);
            }

            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 's';
            paths.Add(new Tuple<int, int>(row, col));

            FindPath(row, col - 1);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);

            lab[row, col] = ' ';
            paths.RemoveAt(paths.Count - 1);
        }

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        private static char[,] GenerateBigMatix(int numberOfRows)
        {
            var matrix = new char[numberOfRows, numberOfRows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ' ';
                }
            }

            var lastRow = matrix.GetLength(0) - 1;
            matrix[lastRow, lastRow] = 'e';

            return matrix;
        }
    }
}
