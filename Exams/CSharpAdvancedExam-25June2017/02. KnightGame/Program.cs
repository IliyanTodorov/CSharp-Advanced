using System;

namespace _02._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Char[][] chess = new char[rows][];

            CreateChess(chess);


            int rowIndex = 0;
            int colIndex = 0;

            int removedKnights = 0;

            while (true)
            {
                int maxAttacker = 0;

                for (int row = 0; row < chess.Length; row++)
                {
                    for (int col = 0; col < chess[row].Length; col++)
                    {
                        int attacked = 0;

                        if (chess[row][col] == 'K')
                        {
                            //up left
                            if (IsInside(chess, row - 2, col - 1) && chess[row - 2][col - 1] == 'K')
                            {
                                attacked++;
                            }

                            //up right
                            if (IsInside(chess, row - 2, col + 1) && chess[row - 2][col + 1] == 'K')
                            {
                                attacked++;
                            }

                            //down left
                            if (IsInside(chess, row + 2, col - 1) && chess[row + 2][col - 1] == 'K')
                            {
                                attacked++;
                            }

                            //down right
                            if (IsInside(chess, row + 2, col + 1) && chess[row + 2][col + 1] == 'K')
                            {
                                attacked++;
                            }

                            //left up
                            if (IsInside(chess, row - 1, col - 2) && chess[row - 1][col - 2] == 'K')
                            {
                                attacked++;
                            }

                            //left down
                            if (IsInside(chess, row + 1, col - 2) && chess[row + 1][col - 2] == 'K')
                            {
                                attacked++;
                            }

                            //right up
                            if (IsInside(chess, row - 1, col + 2) && chess[row - 1][col + 2] == 'K')
                            {
                                attacked++;
                            }

                            //right down
                            if (IsInside(chess, row + 1, col + 2) && chess[row + 1][col + 2] == 'K')
                            {
                                attacked++;
                            }
                        }

                        if (maxAttacker < attacked)
                        {
                            maxAttacker = attacked;
                            rowIndex = row;
                            colIndex = col;
                        }
                    }
                }

                if (maxAttacker > 0)
                {
                    chess[rowIndex][colIndex] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool IsInside(char[][] chess, int row, int col)
        {
            return row >= 0 && row < chess.Length && col >= 0 && col < chess[row].Length;
        }

        private static void CreateChess(Char[][] chess)
        {
            for (int row = 0; row < chess.Length; row++)
            {
                chess[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
