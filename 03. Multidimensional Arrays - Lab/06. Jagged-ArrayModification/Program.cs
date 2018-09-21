namespace _06._Jagged_ArrayModification
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = input;
            }

            while (true)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = tokens[0];

                if (command == "END") // check if input is invalid
                {
                    break;
                }

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= jagged.Length || col < 0 || col >= jagged.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        jagged[row][col] += value;
                        break;
                    case "Subtract":
                        jagged[row][col] -= value;
                        break;
                }
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
