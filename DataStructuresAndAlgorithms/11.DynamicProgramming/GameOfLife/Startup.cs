namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int numberOfMoves = int.Parse(Console.ReadLine());
            var matrix = ReadInputMatrix();

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int i = 0; i < numberOfMoves; i++)
            {
                matrix = IterateAllCells(matrix);
            }

            PrintMatrixOutput(matrix);
        }

        private static byte PerformDeadCellOperation(byte[,] matrix, int curentRow, int currentCol)
        {
            var neighbors = CountNeighbours(matrix, curentRow, currentCol);

            if (neighbors[1] == 3)
            {
                return 1;
            }

            return 0;
        }

        private static byte PerformAliveCellOperation(byte[,] matrix, int curentRow, int currentCol)
        {
            var neighbors = CountNeighbours(matrix, curentRow, currentCol);

            if (neighbors[1] < 2)
            {
                return 0;
            }

            if (neighbors[1] > 3)
            {
                return 0;
            }

            return 1;
        }

        private static int[] CountNeighbours(byte[,] matrix, int currentRow, int currentCol)
        {
            var neighbours = new int[2];
            var maxRow = matrix.GetLength(0) - 1;
            var maxCol = matrix.GetLength(1) - 1;

            for (int row = currentRow == 0 ? 0 : currentRow - 1; row <= (currentRow == maxRow ? maxRow : currentRow + 1); row++)
            {
                for (int col = currentCol == 0 ? 0 : currentCol - 1; col <= (currentCol == maxCol ? maxCol : currentCol + 1); col++)
                {
                    if (row == currentRow && col == currentCol)
                    {
                        continue;
                    }

                    if (matrix[row, col] == 0)
                    {
                        neighbours[0] += 1;
                    }
                    else
                    {
                        neighbours[1] += 1;
                    }
                }
            }

            return neighbours;
        }

        private static byte[,] IterateAllCells(byte[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var newGenerationMatrix = new byte[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        newGenerationMatrix[row, col] = PerformDeadCellOperation(matrix, row, col);
                    }
                    else
                    {
                        newGenerationMatrix[row, col] = PerformAliveCellOperation(matrix, row, col);
                    }
                }
            }

            return newGenerationMatrix;
        }

        private static byte[,] ReadInputMatrix()
        {
            var rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = rowsCols[0];
            var cols = rowsCols[1];

            var matrix = new byte[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }

        private static void PrintMatrixOutput(byte[,] matrix)
        {
            var liveCellsCounter = 0;

            foreach (var cell in matrix)
            {
                if (cell == 1)
                {
                    liveCellsCounter++;
                }
            }

            Console.WriteLine(liveCellsCounter);
        }
    }
}
