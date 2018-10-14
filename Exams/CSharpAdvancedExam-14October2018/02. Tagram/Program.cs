using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Problem
{
    class Program
    {
        static void Main()
        {
            var users = new Dictionary<string, Dictionary<string, int>>();
            var bannedUsers = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var token = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (token.Length > 1)
                {
                    var username = token[0];
                    var tag = token[1];
                    var likes = int.Parse(token[2]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(tag))
                    {
                        users[username].Add(tag, new int());
                    }

                    users[username][tag] += likes;
                }
                else
                {
                    var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var username = tokens[1];

                    if (users.ContainsKey(username))
                    {
                        bannedUsers.Add(username);
                    }
                }
            }

            foreach (var bannedUser in bannedUsers)
            {
                if (users.ContainsKey(bannedUser))
                {
                    users.Remove(bannedUser);
                }
            }

            var ordered = users
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Value.Keys.Count)
                .ToDictionary(x => x.Key, t => t.Value);

            foreach (var kvp in ordered)
            {
                Console.WriteLine(kvp.Key);

                foreach (var tag in kvp.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
