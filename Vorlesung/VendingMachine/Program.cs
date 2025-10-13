using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
class Program
{
    public enum Products
    {
        Bier,
        Wasser
    };
    public class VendingMachine
    {
        private Dictionary<Products, decimal> prices = new Dictionary<Products, decimal>();
        private Dictionary<Products, int> stock = new Dictionary<Products, int>();
        private decimal insertedMoney = 0.0m;

        public VendingMachine()
        {
            prices.Add(Products.Bier, 2.00m);
            prices.Add(Products.Wasser, 8.00m);

            stock.Add(Products.Bier, 10);
            stock.Add(Products.Wasser, 10);
        }

        public void PrintStock()
        {
            foreach (var item in stock)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintPrices()
        {
            foreach (var item in prices)
            {
                Console.WriteLine(item);
            }
        }
        public void AddCoin(decimal value)
        {
            if (value <= 0)
            {
                throw new Exception("value can not be 0");
            }
            insertedMoney += value;
            foreach (var item in prices)
            {
                if (insertedMoney >= item.Value)
                {
                    Console.WriteLine("available " + item.Value +" "+ item.Key);
                }
            }
        }
        public void SelectItem(Products product)
        {
            int count = stock[product];
            decimal price = prices[product];
            if ((count > 0) && (price <= insertedMoney))
            {
                stock[product] = stock[product] - 1;
                insertedMoney = insertedMoney - prices[product];

                Console.WriteLine($"Here is your {product}.");
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }

        }
        public void PrintBestBefore()
        {
            int today = 0;
            
        }
    }
    public static void Main()
    {
        VendingMachine THN = new VendingMachine();
        THN.AddCoin(2.00m);
        THN.SelectItem(Products.Bier);
        THN.SelectItem(Products.Bier);
    }
}