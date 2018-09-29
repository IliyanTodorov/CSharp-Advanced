namespace _01._UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var username = Console.ReadLine();

                set.Add(username);
            }

            foreach (var user in set)
            {
                Console.WriteLine(user);
            }
        }
    }
}
