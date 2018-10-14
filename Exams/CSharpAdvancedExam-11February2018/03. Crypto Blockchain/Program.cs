namespace _03._Crypto_Blockchain
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = String.Empty;

            for (int i = 0; i < n; i++)
            {
                input += Console.ReadLine();
            }

            Regex patter = new Regex(@"({|\[).+?(}|])");
            MatchCollection matches = patter.Matches(input);
            var textResult = String.Empty;

            foreach (Match match in matches)
            {
                if (!MatchingBrackets(match.Value))
                {
                    continue;
                }
                else if (!IsPrintableAscii(match.Value))
                {
                    continue;
                }

                Regex numPattern = new Regex(@"[0-9]{3,}");
                Match numMatch = numPattern.Match(match.Value);

                if (numMatch.Value == "")
                {
                    continue;
                }
                else if (numMatch.Value.Length % 3 != 0)
                {
                    continue;
                }

                var matchLength = match.Value.Length;
                textResult += FindText(numMatch.Value, matchLength);
            }
            Console.WriteLine(textResult);
        }

        private static string FindText(string nums, int length)
        {
            var text = string.Empty;
            int index = 0;
            while (index < nums.Length)
            {
                var currentNum = int.Parse(nums.Substring(index, 3));
                index += 3;
                text += (char)(currentNum - length);
            }
            return text;
        }

        private static bool IsPrintableAscii(string match)
        {
            foreach (var m in match)
            {
                if (m < 32 || m > 126)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool MatchingBrackets(string match)
        {
            var firstBracket = match[0];
            var secondBracket = match[match.Length - 1];

            if (firstBracket == '{' && secondBracket != '}')
            {
                return false;
            }
            else if (firstBracket == '[' && secondBracket != ']')
            {
                return false;
            }

            return true;
        }
    }
}
