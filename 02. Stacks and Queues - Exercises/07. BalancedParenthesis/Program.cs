namespace _07._BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine($"NO");
                return;
            }

            var stack = new Stack<char>();

            var isSolution = false;

            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];

                if (i == 0)
                {
                    stack.Push(currentElement);
                    continue;
                }

                if (currentElement == '{' || currentElement == '[' || currentElement == '(')
                {
                    stack.Push(currentElement);
                }
                else if (currentElement == '}' || currentElement == ']' || currentElement == ')')
                {
                    var previousElement = stack.Pop();

                    if (currentElement == '}' && previousElement == '{')
                    {
                        isSolution = true;
                    }
                    else if (currentElement == ']' && previousElement == '[')
                    {
                        isSolution = true;
                    }
                    else if (currentElement == ')' && previousElement == '(')
                    {
                        isSolution = true;
                    }
                    else
                    {
                        Console.WriteLine($"NO");
                        return;
                    }
                }
            }

            if (isSolution)
            {
                Console.WriteLine($"YES");
            }
        }
    }
}
