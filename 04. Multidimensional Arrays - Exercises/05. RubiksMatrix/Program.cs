namespace _05._RubiksMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            int[][] rubicMatrix = new int[rows][];

            GetMatrix(rubicMatrix, cols);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var column = int.Parse(input[0]);
                var direction = input[1];
                var moves = int.Parse(input[2]);

                switch (direction)
                {
                    case "down":
                        MoveDown(rubicMatrix, column, moves % rubicMatrix.Length);
                        break;
                    case "left":
                        MoveLeft(rubicMatrix, column, moves % rubicMatrix[0].Length);
                        break;
                    case "right":
                        MoveRight(rubicMatrix, column, moves % rubicMatrix[0].Length);
                        break;
                    case "up":
                        MoveUp(rubicMatrix, column, moves % rubicMatrix.Length);
                        break;
                }
            }

            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    if (rubicMatrix[row][col] == counter)
                    {
                        Console.WriteLine($"No swap required");
                        counter++;
                    }
                    else
                    {
                        Rerrange(rubicMatrix, row, col, counter);
                        counter++;
                    }
                }
            }

        }

        private static void Rerrange(int[][] rubicMatrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < rubicMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < rubicMatrix[row].Length; targetCol++)
                {
                    if (rubicMatrix[targetRow][targetCol] == counter )
                    {
                        rubicMatrix[targetRow][targetCol] = rubicMatrix[row][col];
                        rubicMatrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveUp(int[][] rubicMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstEl = rubicMatrix[0][col];

                for (int row = 0; row < rubicMatrix.Length - 1; row++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row + 1][col];
                }

                rubicMatrix[rubicMatrix.Length - 1][col] = firstEl;
            }
        }

        private static void MoveRight(int[][] rubicMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastEl = rubicMatrix[row][rubicMatrix[row].Length - 1];

                for (int col = rubicMatrix.Length - 1; col > 0; col--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row][col - 1];
                }

                rubicMatrix[row][0] = lastEl;
            }
        }

        private static void MoveLeft(int[][] rubicMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstEl = rubicMatrix[row][0];

                for (int col = 0; col < rubicMatrix[row].Length - 1; col++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row][col + 1];
                }

                rubicMatrix[row][rubicMatrix[row].Length - 1] = firstEl;
            }
        }

        private static void MoveDown(int[][] rubicMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastEl = rubicMatrix[rubicMatrix.Length - 1][col];

                for (int row = rubicMatrix.Length - 1; row > 0; row--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row - 1][col];
                }

                rubicMatrix[0][col] = lastEl; 
            }
        }

        private static void GetMatrix(int[][] rubicMatrix, int cols)
        {
            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                rubicMatrix[row] = new int[cols];

                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    rubicMatrix[row][col] = counter++;
                }
            }
        }
    }
}
