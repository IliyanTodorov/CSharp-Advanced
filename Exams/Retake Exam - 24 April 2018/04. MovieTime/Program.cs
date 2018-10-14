namespace _04._MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var movieList = new Dictionary<string, Dictionary<string, TimeSpan>>();

            var favGenre = Console.ReadLine();
            var favDuration = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                string[] inputArgs = input.Split('|');

                string movieName = inputArgs[0];
                string genre = inputArgs[1];
                string duration = inputArgs[2];

                TimeSpan time = TimeSpan.Parse(duration, CultureInfo.InvariantCulture);

                if (!movieList.ContainsKey(genre))
                {
                    movieList.Add(genre, new Dictionary<string, TimeSpan>());
                }

                if (!movieList[genre].ContainsKey(movieName))
                {
                    movieList[genre].Add(movieName, time);
                }
            }

            movieList[favGenre] = movieList[favGenre]
                .OrderBy(x => favDuration == "Short" ? x.Value : -x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var movieKvp in movieList[favGenre])
            {
                Console.WriteLine(movieKvp.Key);
                string wifeCommand = Console.ReadLine();

                if (wifeCommand == "Yes")
                {
                    var seconds = movieList.Values.Sum(x => x.Sum(s => s.Value.TotalSeconds));

                    int totalHours = (int) seconds / 60 / 60;
                    int totalMinutes = (int) seconds / 60 % 60;
                    int totalSeconds = (int) seconds % 60;

                    Console.WriteLine($"We're watching {movieKvp.Key} - {movieKvp.Value}");
                    Console.WriteLine($"Total Playlist Duration: {totalHours:d2}:{totalMinutes:d2}:{totalSeconds:d2}");
                    return;
                }
            }
        }
    }
}
