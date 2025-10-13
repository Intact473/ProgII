using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
class Program
{
    public class VendingMachine
    {
        private Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
        private Dictionary<string, int> stock = new Dictionary<string, int>();
        private decimal insertedMoney = 0.0m;

        public VendingMachine()
        {
            prices.Add("Bier", 2.00m);
            prices.Add("Wasser", 8.00m);

            stock.Add("Bier", 10);
            stock.Add("Wasser", 10);
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
        public void SelectItem(string name)
        {
            int count = stock[name];
            decimal price = prices[name];
            if ((count > 0) && (price <= insertedMoney))
            {
                stock[name] = stock[name] -1;
                insertedMoney = insertedMoney - prices[name];

                Console.WriteLine($"Here is your {name}.");
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }

        }
    }
    public static void Main()
    {
        VendingMachine THN = new VendingMachine();
        // THN.prices["Bier"] = -2.0m;
        THN.AddCoin(2.00m);
        THN.SelectItem("Bier");
        THN.SelectItem("Bier");
        // THN.AddCoin(-2.00m);
        // THN.SelectItem("Orangensaft");
    }
}