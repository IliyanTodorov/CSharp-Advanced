namespace _02._SumNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Func<string, int> parser = n => Int32.Parse(n);

            int[] numbers = input.Split(", ")
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);

            Console.WriteLine(numbers.Sum());
        }
    }
}
