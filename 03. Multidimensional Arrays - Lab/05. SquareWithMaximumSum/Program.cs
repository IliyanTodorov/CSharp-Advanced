namespace _05._SquareWithMaximumSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] jagged = new int[size[0], size[1]];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                var colElements = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < jagged.GetLength(1); col++)
                {
                    jagged[row, col] = colElements[col];
                }
            }



            int sum = 0;
            int bestSum = Int32.MinValue;

            int[,] square = new int[2, 2];

            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < jagged.GetLength(1) - 1; col++)
                {
                    sum += jagged[row, col] + jagged[row, col + 1] +
                           jagged[row + 1, col] + jagged[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;

                        square[0, 0] = jagged[row, col];
                        square[0, 1] = jagged[row, col + 1];
                        square[1, 0] = jagged[row + 1, col];
                        square[1, 1] = jagged[row + 1, col + 1];
                    }

                    sum = 0;
                }
            }

            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write(square[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(bestSum);
        }
    }
}
