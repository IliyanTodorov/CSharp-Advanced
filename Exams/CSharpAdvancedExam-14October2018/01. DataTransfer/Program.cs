using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main()
        {
            int[] cupCapacity = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int[] bottleWithWater = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupCapacity);
            Stack<int> bottles = new Stack<int>(bottleWithWater);

            int wastedWater = 0;
            int bottlesOut = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCupCapacity = cups.Dequeue();
                int currentBottleCapacity= bottles.Pop();
                bottlesOut++;

                if (currentCupCapacity <= currentBottleCapacity)
                {
                    wastedWater += currentBottleCapacity - currentCupCapacity;
                }
                else
                {
                    while (currentCupCapacity > 0)
                    {
                        currentCupCapacity -= currentBottleCapacity;

                        if (currentCupCapacity <= 0)
                        {
                            wastedWater += currentCupCapacity * -1;
                        }
                        else
                        {
                            currentBottleCapacity = bottles.Pop();
                            bottlesOut++;
                        }
                    }
                    
                }
            }

            if (cups.Count > 0 && bottles.Count == 0)
            {
                Console.Write($"Cups: ");
                foreach (var cup in cups)
                {
                    Console.Write($"{cup} ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.Write($"Bottles: ");
                foreach (var bottle in bottles)
                {
                    Console.Write($"{bottle} ");
                }

                Console.WriteLine();
            }
            
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
