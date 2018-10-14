namespace _02._Sneaking
{
    using System;
    using System.Linq;

    class Program // 80/100
    {
        static int SamRow;
        static int SamCol;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                if (matrix[row].Contains('S'))
                {
                    SamRow = row;
                    SamCol = Array.IndexOf(matrix[row], 'S');
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies(matrix);

                DoesSamDie(matrix);
                
                MoveSam(matrix, directions[i]);

                DoesSamWin(matrix);
            }

        }

        private static void DoesSamWin(char[][] matrix)
        {
            if (matrix[SamRow].Contains('N'))
            {
                matrix[SamRow][Array.IndexOf(matrix[SamRow], 'N')] = 'X';
                Console.WriteLine($"Nikoladze killed!");
                Print(matrix);
                Environment.Exit(1);
            }
        }

        private static void MoveSam(char[][] matrix, char move)
        {
            switch (move)
            {
                case 'U':
                    Move(matrix, -1, 0);
                    break;
                case 'D':
                    Move(matrix, 1, 0);
                    break;
                case 'L':
                    Move(matrix, 0, -1);
                    break;
                case 'R':
                    Move(matrix, 0, 1);
                    break;
                default:
                    break;

            }
        }

        private static void Move(char[][] matrix, int targetRow, int targetCol)
        {
            targetRow = SamRow + targetRow;
            targetCol = SamCol + targetCol;

            if (targetRow != -1 && targetRow <= matrix.GetLength(0) &&
                targetCol > 0 && targetCol < matrix[0].Length)
            {
                matrix[SamRow][SamCol] = '.';
                matrix[targetRow][targetCol] = 'S';

                SamRow = targetRow;
                SamCol = targetCol; 
            }
        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }

        private static void DoesSamDie(char[][] matrix)
        {
            int enemyCol;
            bool isDead = false;

            if (matrix[SamRow].Contains('b'))
            {
                enemyCol = Array.IndexOf(matrix[SamRow], 'b');
                if (enemyCol < SamCol)
                {
                    isDead = true;
                }
            }
            else if (matrix[SamRow].Contains('d'))
            {
                enemyCol = Array.IndexOf(matrix[SamRow], 'd');
                if (enemyCol > SamCol)
                {
                    isDead = true;
                }
            }

            if (isDead)
            {
                matrix[SamRow][SamCol] = 'X';
                Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                Print(matrix);
                Environment.Exit(1);
            }
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int enemyCol;

                if (matrix[row].Contains('b'))
                {
                    enemyCol = Array.IndexOf(matrix[row], 'b');
                    if (enemyCol != matrix[row].Length - 1)
                    {
                        matrix[row][enemyCol] = '.';
                        matrix[row][enemyCol + 1] = 'b';
                    }
                    else
                    {
                        matrix[row][enemyCol] = 'd';
                    }
                }
                else if (matrix[row].Contains('d'))
                {
                    enemyCol = Array.IndexOf(matrix[row], 'd');
                    if (enemyCol != 0)
                    {
                        matrix[row][enemyCol] = '.';
                        matrix[row][enemyCol - 1] = 'd';
                    }
                    else
                    {
                        matrix[row][enemyCol] = 'b';
                    }
                }
            }
        }
    }
}
