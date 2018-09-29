namespace _03._PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var compounds = int.Parse(Console.ReadLine());

            var set = new SortedSet<string>();

            for (int i = 0; i < compounds; i++)
            {
                var chemicals = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < chemicals.Length; j++)
                {
                    set.Add(chemicals[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
