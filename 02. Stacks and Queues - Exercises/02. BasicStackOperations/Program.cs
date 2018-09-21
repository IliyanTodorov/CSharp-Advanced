namespace _02._BasicStackOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var s = input[1];
            var x = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine($"0");
                return;
            }

            if (stack.Contains(x))
            {
                Console.WriteLine($"true");
            }
            else
            {
                int minNum = stack.Pop();

                while (stack.Count >= 1)
                {
                    if (minNum > stack.Peek())
                    {
                        minNum = stack.Pop();
                        continue;
                    }

                    stack.Pop();
                }

                Console.WriteLine(minNum);
            }
        }
    }
}
