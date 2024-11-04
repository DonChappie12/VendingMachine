using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class VendingItem
    {
        public string ProductName;
        public int Price;
        public int StockAmount;
        public VendingItem(string ProductName, int Price, int StockAmount)
        {
            this.ProductName = ProductName;
            this.Price = Price;
            this.StockAmount = StockAmount;
        }

        public bool RemoveItem()
        {
            if(this.StockAmount>0)
            {
                this.StockAmount--;
                Console.WriteLine($"{this.ProductName} remaining {this.StockAmount}");
                return true;
            } else {
                Console.WriteLine("We apologize we are out of stock of this item");
                return false;
            }
        }
    }
}