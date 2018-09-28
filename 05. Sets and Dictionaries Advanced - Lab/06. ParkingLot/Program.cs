namespace _06._ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var parking = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var token = input
                    .Split(", ")
                    .ToArray();
                
                var command = token[0];
                var car = token[1];

                switch (command)
                {
                    case "IN":
                        parking.Add(car);
                        break;
                    case "OUT":
                        parking.Remove(car);
                        break;
                }
            }

            if (parking.Count == 0)
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
