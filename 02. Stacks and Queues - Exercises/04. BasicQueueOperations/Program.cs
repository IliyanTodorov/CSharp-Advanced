namespace _04._BasicQueueOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var s = input[1];
            var x = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"0");
                return;
            }

            if (queue.Contains(x))
            {
                Console.WriteLine($"true");
            }
            else
            {
                int minNum = queue.Dequeue();

                while (queue.Count >= 1)
                {
                    if (minNum > queue.Peek())
                    {
                        minNum = queue.Dequeue();
                        continue;
                    }

                    queue.Dequeue();
                }

                Console.WriteLine(minNum);
            }
        }
    }
}
