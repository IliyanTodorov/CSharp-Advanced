namespace _03._CountUppercaseWords
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Func<string, bool> cheker = word => word[0] == word.ToUpper()[0];

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(cheker)
                .ToArray();

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
