using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var values = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var Operator = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                var result = 0;

                switch (Operator)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
