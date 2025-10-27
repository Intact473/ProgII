using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.CompilerServices;

class Program
{
    public class Product
    {
        public static int counter = 0;
        private int id;
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public Product(string Name, decimal Prices)
        {
            this.id = counter;
            counter = counter + 1;

            this.Name = Name;
            this.Price = Prices;

        }
        public override string ToString()
        {
            return "Name: "+ Name + " (" + id + ")";
        }
    }
    public class Drink: Product
    {
        public int BestBeforeDays{ get; private set; }
        public Drink(string name, decimal price, int BestBeforeDays) : base(name, price)
        {
            this.BestBeforeDays = BestBeforeDays;
        }

    }
    public class VendingMachine
    {
        private Dictionary<Product, uint> stock = new Dictionary<Product, uint>();
        private decimal insertedMoney = 0.0m;
        public List<Product> availableProducts;

        public VendingMachine()
        {
            availableProducts = new List<Product>();
        }


        public void Refill(Product product)
        {
            availableProducts.Add(product);
        }

        public void PrintAvailableProducts()
        {
            foreach (var product in availableProducts)
            {
                Console.WriteLine(product);
            }
        }
        public void PrintPrices()
        {

            foreach (var product in availableProducts)
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
        }
        public void Select(string productName)
        {
            foreach (Product product in availableProducts)
            {

                if ((product.Name == productName) && (product.Price <= insertedMoney))
                {
                    if ((product is Drink drink && drink.BestBeforeDays > 0) || product is Product)
                    {
                        insertedMoney = insertedMoney - product.Price;
                        availableProducts.Remove(product);
                        Console.WriteLine($"Here is your {product}.");
                        return;

                    }
                }
            }
            Console.WriteLine("Not enough Money");
        }

    }
    
    public static void Main()
    {
        Drink P1 = new Drink(Name: "Cola", Prices: 2.0m);
        Drink P2 = new Drink(Name: "Bier", Prices: 3.0m);
        // P1.Prices = 500.0m;

        VendingMachine THN = new VendingMachine();
        THN.Refill(P1);
        THN.Refill(P2);
        THN.PrintAvailableProducts();
        THN.AddCoin(2.0m);
        THN.Select("Cola");
        THN.Select("Bier");
        // THN.Select("Cola");
        // THN.SelectItem(Product.Bier);
        // THN.SelectItem(Product.Bier);

    }
}