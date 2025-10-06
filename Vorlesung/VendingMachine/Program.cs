using System;
using System.ComponentModel.DataAnnotations.Schema;
class Program
{
    public class VendingMachine
    {
        public Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
        public Dictionary<string, int> stock = new Dictionary<string, int>();

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
    }
    public static void Main()
    {

        VendingMachine THN = new VendingMachine();
        THN.PrintStock();
    }
}