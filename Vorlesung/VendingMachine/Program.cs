using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.CompilerServices;

class Program
{
    public class Product
    {
        private int id;
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public Product(int ID, string Name, decimal Prices)
        {
            this.id = ID;
            this.Name = Name;
            this.Price = Prices;
        }
    }
    public class Drink: Product
    {
        private int bestBeforeDays;
        public Drink(int id, string name, decimal price, int bestBeforeDays) : base(id, name, price)
        {
            this.bestBeforeDays = bestBeforeDays;
        }

    }
    public class VendingMachine
    {
        private Dictionary<Product, uint> stock = new Dictionary<Product, uint>();
        private decimal insertedMoney = 0.0m;

        public VendingMachine()
        {
            
        }
        public void Refill(Product product,uint stock)
        {
            if (!this.stock.TryAdd(product, stock))
            {
                this.stock[product] = this.stock[product] + stock;
            }
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
            
            foreach (var product in stock.Keys)
            {
                Console.WriteLine(product);
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
                    Console.WriteLine("available " + item.Value + " " + item.Key);
                }
            }
        }
        public void SelectItem(Product product)
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
        Product P1 = new Product(ID: 1, Name: "Cola", Prices: 20.0m);
        Product P2 = new Product(ID: 1, Name: "Bier", Prices: 30.0m);
        // P1.Prices = 500.0m;
        
        // VendingMachine THN = new VendingMachine();
        // THN.AddCoin(2.00m);
        // THN.SelectItem(Product.Bier);
        // THN.SelectItem(Product.Bier);

    }
}