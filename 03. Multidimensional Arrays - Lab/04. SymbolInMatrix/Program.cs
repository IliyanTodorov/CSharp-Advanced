namespace _04._SymbolInjagged
{
    using System;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            Char[,] jagged = new Char[size, size];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                var colElements = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < jagged.GetLength(1); col++)
                {
                    jagged[row, col] = colElements[col];
                }
            }

            var symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged.GetLength(1); col++)
                {
                    int rowIndex = 0;
                    int colIndex = 0;

                    if (jagged[row, col] == symbol)
                    {
                        rowIndex = row;
                        colIndex = col;
                        Console.WriteLine($"({rowIndex}, {colIndex})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the jagged");
        }
    }
}
