using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--" + "\"(?<message>[A-Za-z\\s]+)\"";

            int n = int.Parse(Console.ReadLine());

            List<string> valid = new List<string>();
            int totalData = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string sender = match.Groups[1].Value;
                    string receiver = match.Groups[2].Value;
                    string message = match.Groups[3].Value;

                    var senderUserName = String.Empty;
                    string namePattern = @"[A-Za-z ]+";

                    MatchCollection matchesSender = Regex.Matches(sender, namePattern);
                    foreach (var match1 in matchesSender)
                    {
                        senderUserName += match1.ToString();
                    }

                    var recevierUserName = String.Empty;

                    MatchCollection matchesRecevier = Regex.Matches(receiver, namePattern);
                    foreach (var match1 in matchesRecevier)
                    {
                        recevierUserName += match1.ToString();
                    }

                    //var senderName = new String(sender.Where(Char.IsLetter).ToArray());
                    //var recieverName = new String(receiver.Where(Char.IsLetter).ToArray());
                    
                    Console.WriteLine($"{senderUserName} says \"{message}\" to {recevierUserName}");

                    totalData += GetSizeData(sender, receiver);
                }
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");

        }

        private static string GetNameOfSender(string sender)
        {
            var name = string.Empty;
            var x = sender.ToCharArray();
            for (int i = 0; i <= x.Length; i++)
            {
                if (x[i] > 'A' || x[i] <= 'Z' || x[i] > 'a' || x[i] <= 'z')
                {
                    name += x[i];
                }
            }

            return name;
        }

        private static int GetSizeData(string sender, string receiver)
        {
            int sum = 0;
            var x = sender.ToCharArray();
            for (int I = 0; I <= x.Length - 1; I++)
            {
                if (x[I] > '0' && x[I] <= '9')
                {
                    sum += x[I] - '0';
                }
            }

            var y = receiver.ToCharArray();
            for (int I = 0; I <= y.Length - 1; I++)
            {
                if (y[I] > '0' && y[I] <= '9')
                {
                    sum += y[I] - '0';
                }
            }

            return sum;
        }
    }
}
