namespace _04._Hit_List
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var people = new Dictionary<string, SortedDictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split('=');
                string name = tokens[0];
                string[] kvps = tokens[1].Split(';');


                if (!people.ContainsKey(name))
                {
                    people.Add(name, new SortedDictionary<string, string>());
                }

                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] kvp = kvps[i].Split(':');
                    var key = kvp[0];
                    var value = kvp[1];

                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }
                    else
                    {
                        people[name][key] = value;
                    }
                }
            }

            var killed = Console.ReadLine();
            killed = killed.Remove(0, 5);

            var infoIndex = 0;

            Console.WriteLine($"Info on {killed}:");
            foreach (var kvp in people[killed])
            {
                infoIndex += kvp.Key.Length + kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
