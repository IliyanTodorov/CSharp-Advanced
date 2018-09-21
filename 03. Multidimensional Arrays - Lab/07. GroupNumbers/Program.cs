namespace _07._GroupNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var jaggedArr = new int[3][];

            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(" ", input.Where(x => Math.Abs(x) % 3 == 0)));
            Console.WriteLine(string.Join(" ", input.Where(x => Math.Abs(x) % 3 == 1)));
            Console.WriteLine(string.Join(" ", input.Where(x => Math.Abs(x) % 3 == 2)));
            
        }
    }
}
