using System;
using System.Collections.Generic;

namespace _04._MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackOpenBracketIndex = new Stack<int>();
            for (int counter = 0; counter < input.Length; counter++)
            {
                if (input[counter] == '(')
                {
                    stackOpenBracketIndex.Push(counter);
                }

                if (input[counter] == ')')
                {
                    var openBracketIndex = stackOpenBracketIndex.Pop();
                    var length = counter - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
