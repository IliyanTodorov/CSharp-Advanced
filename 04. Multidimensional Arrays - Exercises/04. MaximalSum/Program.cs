using System;
using System.Data;
using System.Linq;

namespace _04._MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[][] matrix = new int[size[0]][];

            for (int i = 0; i < size[0]; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int currentValue;
            int maxSum = Int32.MinValue;
            var rowIndex = 0;
            var colIndex = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    currentValue = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                                       matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                                       matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentValue > maxSum)
                    {
                        maxSum = currentValue;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[rowIndex][colIndex]} " +
                              $"{matrix[rowIndex][colIndex + 1]} " +
                              $"{matrix[rowIndex][colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 1][colIndex]} " +
                              $"{matrix[rowIndex + 1][colIndex + 1]} " +
                              $"{matrix[rowIndex + 1][colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 2][colIndex]} " +
                              $"{matrix[rowIndex + 2][colIndex + 1]} " +
                              $"{matrix[rowIndex + 2][colIndex + 2]}");

        }
    }
}
