namespace _02._SumjaggedColumns
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] jagged = new int[sizes[0], sizes[1]];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < jagged.GetLength(1); col++)
                {
                    jagged[row, col] = colElements[col];
                }
            }

            int sum = 0;
            for (int col = 0; col < jagged.GetLength(1); col++)
            {
                for (int row = 0; row < jagged.GetLength(0); row++)
                {
                    sum += jagged[row, col];

                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
