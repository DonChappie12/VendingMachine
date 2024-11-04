using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Drink : VendingItem
    {
        public Drink(string ProductName, int Price, int StockAmount) : base(ProductName, Price, StockAmount)
        {
        }
    }
}