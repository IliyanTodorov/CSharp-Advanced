namespace _01._ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>(input);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
