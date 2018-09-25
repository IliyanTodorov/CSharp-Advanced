using System;
using System.Linq;

namespace _07._LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[rows][];
            int[][] secondJaggedArray = new int[rows][];

            GetJaggedArray(firstJaggedArray, rows);
            GetJaggedArray(secondJaggedArray, rows);

            bool isCompatible = CompatibleChecker(firstJaggedArray, secondJaggedArray);

            if (isCompatible)
            {
                Print(ArraysConcatenation(firstJaggedArray, secondJaggedArray));
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {TotalCells(firstJaggedArray, secondJaggedArray)}");
            }
        }

        private static int TotalCells(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            int totalCells = 0;

            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                totalCells += firstJaggedArray[row].Length;
            }

            for (int row = 0; row < secondJaggedArray.Length; row++)
            {
                totalCells += secondJaggedArray[row].Length;
            }

            return totalCells;
        }

        private static void Print(int[][] theArray)
        {
            for (int row = 0; row < theArray.Length; row++)
            {
                Console.WriteLine($"[{string.Join(", ", theArray[row])}]");
            }
        }

        private static int[][] ArraysConcatenation(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            int colLength = ColumnLength(firstJaggedArray, secondJaggedArray);

            var resultArr = new int[firstJaggedArray.Length][];

            secondJaggedArray = ReverseJaggedArray(secondJaggedArray);

            int counter = 0;

            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                resultArr[row]= new int[colLength];

                for (int col = 0; col < colLength; col++)
                {
                    if (col >= firstJaggedArray[row].Length)
                    {
                        resultArr[row][col] = secondJaggedArray[row][counter++];
                    }
                    else
                    {
                        resultArr[row][col] = firstJaggedArray[row][col];
                    }
                }

                counter = 0;
            }

            return resultArr;
        }

        private static bool CompatibleChecker(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            int colLength = ColumnLength(firstJaggedArray, secondJaggedArray);

            bool isCompatible = true;

            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                int currentColLengthOfFirstJaggedArr = firstJaggedArray[row].Length;
                int currentColLengthOfSecondJaggedArr = secondJaggedArray[row].Length;

                if (currentColLengthOfFirstJaggedArr + currentColLengthOfSecondJaggedArr != colLength)
                {
                    isCompatible = false;
                }

            }

            return isCompatible;
        }

        private static int ColumnLength(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            return firstJaggedArray[0].Length + secondJaggedArray[0].Length;
        }

        private static void GetJaggedArray(int[][] jaggedArray, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var column = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


                jaggedArray[row] = column;
            }
        }

        public static int[][] ReverseJaggedArray(int[][] theArray)
        {
            for (int rowIndex = 0;
                rowIndex <= (theArray.GetUpperBound(0)); rowIndex++)
            {
                for (int colIndex = 0;
                    colIndex <= (theArray[rowIndex].GetUpperBound(0) / 2);
                    colIndex++)
                {
                    int tempHolder = theArray[rowIndex][colIndex];
                    theArray[rowIndex][colIndex] =
                        theArray[rowIndex][theArray[rowIndex].GetUpperBound(0) -
                                           colIndex];
                    theArray[rowIndex][theArray[rowIndex].GetUpperBound(0) -
                                       colIndex] = tempHolder;
                }
            }

            return theArray;
        }
    }
}
