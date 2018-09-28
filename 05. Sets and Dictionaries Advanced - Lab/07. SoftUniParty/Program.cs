namespace _07._SoftUniParty
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var guests = new HashSet<string>();
            var vips = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(input[0]))
                {
                    vips.Add(input);
                    continue;
                }

                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (Char.IsDigit(input[0]))
                {
                    vips.Remove(input);
                    continue;
                }

                guests.Remove(input);
            }

            Console.WriteLine(vips.Count + guests.Count);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
