namespace _08._PascalTriangle
{
    using System;

    class Program
    {
        static void Main()
        {
            int rowCount = Int32.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rowCount][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][jaggedArray[i].Length - 1] = 1;
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (col != 0 && col != jaggedArray[row].Length - 1)
                    {
                        long sum = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                        jaggedArray[row][col] = sum;
                    }
                }
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
