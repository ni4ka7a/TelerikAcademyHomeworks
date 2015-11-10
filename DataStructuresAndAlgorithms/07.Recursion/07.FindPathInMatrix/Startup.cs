namespace _07.FindPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

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

        private static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();

        public static void Main(string[] args)
        {
            // Start the app and follow the path
            FindPath(0, 0);
            Console.WriteLine("No more paths available");
        }

        private static void FindPath(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                PrintPath();
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

        private static void PrintPath()
        {
            char[,] matrix =
             {
                 { '|', ' ', ' ', ' ', '*', ' ', ' ', ' ', '|' },
                 { '|', '*', '*', ' ', '*', ' ', '*', ' ', '|' },
                 { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                 { '|', ' ', '*', '*', '*', '*', '*', ' ', '|' },
                 { '|', ' ', ' ', ' ', ' ', ' ', ' ', 'e', '|' },
             };

            foreach (var cell in paths)
            {
                Console.CursorVisible = false;
                Console.Clear();
                matrix[cell.Item1, cell.Item2 + 1] = '-';
                PrintMatrix(matrix);
                Thread.Sleep(500);
            }

            Console.CursorVisible = true;
            Console.WriteLine("\nPress any key to find the next path");
            Console.ReadKey();
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}
