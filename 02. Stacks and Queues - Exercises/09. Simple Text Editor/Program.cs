namespace _09._SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var stack = new Stack<string>();

            string text = string.Empty;

            int operations = int.Parse(Console.ReadLine());


            for (int i = 0; i < operations; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var command = input[0];

                switch (command)
                {
                    case "1":
                        var additionalText = input[1];
                        stack.Push(text);
                        text += additionalText;
                        break;
                    case "2":
                        stack.Push(text);
                        int count = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - count);
                        break;
                    case "3":
                        var index = int.Parse(input[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = stack.Pop();
                        break;
                }
            }
        }
    }
}
