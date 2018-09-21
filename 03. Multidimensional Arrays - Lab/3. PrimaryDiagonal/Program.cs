namespace _3._PrimaryDiagonal
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] jagged = new int[size, size];

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

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                var col = row;
                sum += jagged[row, col];
            }

            Console.WriteLine(sum);
        }
    }
}
