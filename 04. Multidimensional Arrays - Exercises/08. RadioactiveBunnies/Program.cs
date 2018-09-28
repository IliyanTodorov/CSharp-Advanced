namespace _08._RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program // 80/100
    {
        static int playerRow;
        static int playerCol;
        static char[][] matrix;
        static bool isDead;
        static bool isOutside;

        static void Main()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = size[0];
            var cols = size[1];

            matrix = new char[rows][];

            GetMatrix(cols);

            var directions = Console.ReadLine().ToCharArray();

            MovePlayer(directions);

            Print(matrix);
        }

        private static void MovePlayer(char[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                var direction = directions[i];

                switch (direction)
                {
                    case 'U':
                        Move(-1, 0);
                        break;
                    case 'D':
                        Move(1, 0);
                        break;
                    case 'L':
                        Move(0, -1);
                        break;
                    case 'R':
                        Move(0, 1);
                        break;
                }

                Spread();

                if (isDead)
                {
                    Print(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(1);
                }
                else if (isOutside)
                {
                    Print(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    Environment.Exit(1);
                }
            }

        }

        private static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (!IsInside(targetRow, targetCol))
            {
                matrix[playerRow][playerCol] = '.';
                isOutside = true;
            }
            else if (IsBunny(targetRow, targetCol))
            {
                matrix[playerRow][playerCol] = '.';
                playerRow += row;
                playerCol += col;  

                isDead = true;
            }
            else
            {
                matrix[playerRow][playerCol] = '.';

                playerRow += row;
                playerCol += col;
            }


            
        }

        private static bool IsBunny(int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol] == 'B';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void Spread()
        {
            Queue<int[]> indexes = new Queue<int[]>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                { 
                    var currentIndexElement = matrix[row][col];

                    if (currentIndexElement == 'B')
                    {
                        indexes.Enqueue(new int[] {row, col});
                    }
                }
            }

            while (indexes.Count > 0)
            {
                int[] currentIndex = indexes.Dequeue();

                int targetRow = currentIndex[0];
                int targetCol = currentIndex[1];

                if (IsInside(targetRow - 1, targetCol))
                {
                    if (matrix[targetRow - 1][targetCol] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[targetRow - 1][targetCol] = 'B';
                }

                if (IsInside(targetRow + 1, targetCol))
                {
                    if (matrix[targetRow + 1][targetCol] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[targetRow + 1][targetCol] = 'B';
                }

                if (IsInside(targetRow, targetCol + 1))
                {
                    if (matrix[targetRow][targetCol + 1] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[targetRow][targetCol + 1] = 'B';
                }

                if (IsInside(targetRow, targetCol - 1))
                {
                    if (matrix[targetRow][targetCol - 1] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[targetRow][targetCol - 1] = 'B';
                }
            }
        }

        private static void GetMatrix(int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
