using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            char[][] matrix = new char[rows][];

            string snake = Console.ReadLine();

            GetMatrix(matrix, columns, snake);

            var shotParam = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Shoot(matrix, shotParam);

            Collapse(matrix);

            Print(matrix);

        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elemens = new Queue<char>(matrix.Length);
            
            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elemens.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elemens.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] shotParam)
        {
            int impactRow = shotParam[0];
            int impactCol = shotParam[1];
            int radius = shotParam[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((impactRow - row), 2) + Math.Pow((impactCol - col), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void GetMatrix(char[][] matrix, int columns, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[columns];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = true;
                }
                
            }
        }

        private static int SetLetter(char[][] matrix, string snake, int counter, int row, int col)
        {
            if (counter > snake.Length - 1)
            {
                counter = 0;
            }

            matrix[row][col] = snake[counter++];
            return counter;
        }
    }
}
