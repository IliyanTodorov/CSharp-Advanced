namespace _1._SumjaggedElements
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
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < jagged.GetLength(1); col++)
                {
                    jagged[row, col] = colElements[col];
                }
            }

            int sum = 0;
            foreach (var element in jagged)
            {
                sum += element;
            }

            Console.WriteLine(sizes[0]);
            Console.WriteLine(sizes[1]);
            Console.WriteLine(sum);
        }
    }
}
