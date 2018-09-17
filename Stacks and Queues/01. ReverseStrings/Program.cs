using System;
using System.Collections.Generic;

namespace _01._ReverseStrings
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>(input.ToCharArray());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
