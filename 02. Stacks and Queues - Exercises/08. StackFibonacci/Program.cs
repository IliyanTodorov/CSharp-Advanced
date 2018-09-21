namespace _08._StackFibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Int32.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < input; i++)
            {
                var currentNumber = stack.Pop();
                var prevNumber = stack.Pop();

                stack.Push(currentNumber);
                stack.Push(currentNumber + prevNumber);
            }

            stack.Pop();

            Console.WriteLine(stack.Pop());
        }
    }
}
