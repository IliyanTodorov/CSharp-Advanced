namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var colorsAndClothes = new Dictionary<string, HashSet<string>>();
            var countDuplicates = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];
                var clothes = input[1].Split(',');

                if (!colorsAndClothes.ContainsKey(color))
                {
                    colorsAndClothes.Add(color, new HashSet<string>());
                    countDuplicates.Add(color, new Dictionary<string, int>());
                }

                foreach (var cl in clothes)
                {
                    colorsAndClothes[color].Add(cl);
                    if (!countDuplicates[color].ContainsKey(cl))
                    {
                        countDuplicates[color].Add(cl, 0);
                    }

                    countDuplicates[color][cl]++;
                }
            }

            var target = Console.ReadLine().Split().ToArray();
            string targetColor = target[0];
            string targetCloth = target[1];

            foreach (var kvp in colorsAndClothes)
            {
                var color = kvp.Key;
                var set = kvp.Value;
                Console.WriteLine($"{color} clothes:");
                foreach (var item in set)
                {
                    var counter = countDuplicates[color][item];
                    if (color == targetColor && item == targetCloth)
                    {
                        Console.WriteLine($"* {item} - {counter} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item} - {counter}");
                }
            }
        }
    }
}
