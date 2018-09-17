using System;
using System.Collections.Generic;

namespace _06._TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            int count = 0;
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {

                        if (queue.Count > 0)
                        {
                            count++;
                            Console.WriteLine(queue.Dequeue() + " passed!");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");


        }
    }
}
