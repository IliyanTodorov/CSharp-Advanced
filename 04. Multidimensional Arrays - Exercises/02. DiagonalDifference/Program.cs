using System;
using System.Linq;

namespace _02._DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int primaryDiagonal = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                primaryDiagonal += matrix[row][row];
            }

            int secondaryDiagonal = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                secondaryDiagonal += matrix[row][matrix.GetLength(0) - 1 - row];
            }

            int diff = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine($"{diff}");

            
        }
    }
}
