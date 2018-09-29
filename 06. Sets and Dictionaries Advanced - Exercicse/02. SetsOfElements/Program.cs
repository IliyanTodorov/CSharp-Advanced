namespace _02._SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] length = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            for (int i = 1; i <= length[0] + length[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i <= length[0])
                {
                    set1.Add(num);
                }
                else
                {
                    set2.Add(num);
                }
            }

            set1.IntersectWith(set2);
            foreach (var num in set1)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();
        }
    }
}
