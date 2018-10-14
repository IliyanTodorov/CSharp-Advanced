using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string pattern = @"\[[A-Za-z]+<([0-9]+)REGEH([0-9]+)>[A-Za-z]+]";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            { 
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }

            int numSum = 0;
            string result = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                numSum += numbers[i];
                numSum %= input.Length;
                result += input[numSum];
            }

            Console.WriteLine(result);
        }
    }
}
