namespace _01._Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            int totalCarsPassed = 0;

            var lane = new Queue<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input != "green")
                {
                    lane.Enqueue(input);
                    continue;
                }

                var currentLightDuration = greenLightDuration;

                string passingCar = null;
                while (currentLightDuration > 0 && lane.Any())
                {
                    passingCar = lane.Dequeue();
                    currentLightDuration -= passingCar.Length;
                    totalCarsPassed++;
                }

                int freeWindowLeft = freeWindowDuration + currentLightDuration;
                if (freeWindowLeft < 0)
                {
                    int symbolsThatDidntPass = Math.Abs(freeWindowLeft);
                    int indexOfHitSymbol = passingCar.Length - symbolsThatDidntPass;
                    char symbolHit = passingCar[indexOfHitSymbol];
                    Crash(passingCar, symbolHit);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void Crash(string passingCar, char symbolHit)
        {
            Console.WriteLine($"A crash happened!");
            Console.WriteLine($"{passingCar} was hit at {symbolHit}.");
            Environment.Exit(0);
        }
    }
}
