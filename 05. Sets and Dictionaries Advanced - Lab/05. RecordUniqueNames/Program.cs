namespace _05._RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                set.Add(name);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
