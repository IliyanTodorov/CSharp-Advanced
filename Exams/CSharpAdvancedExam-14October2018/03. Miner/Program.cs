using System;
using System.Linq;

namespace _02._Problem
{
    class Program
    {
        static int SamRow;
        static int SamCol;
        static int Coal;
        static int AllCoal;

        static void Main()
        {
            long rows = long.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine().Split();

            String[][] jaggedArray = new String[rows][];

            for (int row = 0; row < rows; row++)
            {
                var inputLine = Console.ReadLine().Split().ToArray();

                jaggedArray[row] = new string[inputLine.Length];

                for (int col = 0; col < inputLine.Length; col++)
                {
                    jaggedArray[row][col] = inputLine[col];

                    if (jaggedArray[row][col] == "c")
                    {
                        AllCoal++;
                    }

                    if (jaggedArray[row][col] == "s")
                    {
                        SamRow = row;
                        SamCol = Array.IndexOf(jaggedArray[row], "s");
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                MoveSam(jaggedArray, directions[i]);
            }

            Console.WriteLine($"{AllCoal - Coal} coals left. ({SamRow}, {SamCol})");
        }

        private static void MoveSam(String[][] jaggedArray, string move)
        {
            switch (move)
            {
                case "up":
                    Move(jaggedArray, -1, 0);
                    break;
                case "down":
                    Move(jaggedArray, 1, 0);
                    break;
                case "left":
                    Move(jaggedArray, 0, -1);
                    break;
                case "right":
                    Move(jaggedArray, 0, 1);
                    break;
                default:
                    break;

            }
        }

        private static void Move(String[][] jaggedArray, int targetRow, int targetCol)
        {
            targetRow = SamRow + targetRow;
            targetCol = SamCol + targetCol;

            if (targetRow != -1 && targetRow < jaggedArray.GetLength(0) &&
                targetCol >= 0 && targetCol < jaggedArray[0].Length)
            {
                jaggedArray[SamRow][SamCol] = "*";

                if (jaggedArray[targetRow][targetCol] == "c")
                {
                    Coal++;
                    if (Coal == AllCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({targetRow}, {targetCol})");
                        Environment.Exit(0);
                    }
                }
                else if (jaggedArray[targetRow][targetCol] == "e")
                {
                    Console.WriteLine($"Game over! ({targetRow}, {targetCol})");
                    Environment.Exit(0);
                }

                jaggedArray[targetRow][targetCol] = "s";

                SamRow = targetRow;
                SamCol = targetCol;
            }
        }
    }
}
