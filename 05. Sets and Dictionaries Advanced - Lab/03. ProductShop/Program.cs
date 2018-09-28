using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            string line;

            while ((line = Console.ReadLine()) != "Revision")
            {
                string[] productsInfo = line.Split(", ");
                string shop = productsInfo[0];
                string product = productsInfo[1];
                double price = double.Parse(productsInfo[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var tokens in shop.Value)
                {
                    Console.WriteLine($"Product: {tokens.Key}, Price: {tokens.Value}");
                }
            }
        }
    }
}
