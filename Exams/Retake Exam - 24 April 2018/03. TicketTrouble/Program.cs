namespace _03._TicketTrouble
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            List<string> valid = new List<string>();

            string curlyPattern = @"{[^}]+\[([A-Z]{3} [A-Z]{2})].+?\[([A-Z]{1}[0-9]{1,2})][^\}]+}";
            string squarePattern = @"\[[^]]+\{([A-Z]{3} [A-Z]{2})}.+?\{([A-Z]{1}[0-9]{1,2})}[^\]]+]";

            string destination = Console.ReadLine();
            string input = Console.ReadLine();

            MatchCollection squareMatches = Regex.Matches(input, squarePattern);
            MatchCollection curlyMatches = Regex.Matches(input, curlyPattern);

            AddSeats(destination, squareMatches, valid);
            AddSeats(destination, curlyMatches, valid);

            if (valid.Count == 2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {valid[0]} and {valid[1]}.");
            }
            else
            {
                for (int i = 0; i < valid.Count; i++)
                {
                    for (int j = i + 1; j < valid.Count; j++)
                    {
                        string firstSeat = valid[i].Substring(1);
                        string secondSeat = valid[j].Substring(1);

                        if (firstSeat == secondSeat)
                        {
                            Console.WriteLine($"You are traveling to {destination} on seats {valid[i]} and {valid[j]}.");
                            return;
                        }
                    }
                }
            }
        }

        private static void AddSeats(string destination, MatchCollection curlyMatches, List<string> valid)
        {
            foreach (Match match in curlyMatches)
            {
                if (match.Groups[1].Value.Contains(destination))
                {
                    valid.Add(match.Groups[2].Value);
                }
            }
        }
    }
}
