using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class VendingMachine
    {
        private int DepositedAmount;
        public Money money;
        const int STARTING_AMOUNT = 5;
        Dictionary<int, VendingItem> VendingItems = new Dictionary<int, VendingItem>();

        public VendingMachine()
        {
            DepositedAmount = 0;
            money = new Money();

            List<Drink> drinks = new List<Drink>()
            {
                new Drink("Sprite", 150, STARTING_AMOUNT),
                new Drink("Apple Juice", 125, STARTING_AMOUNT),
                new Drink("Coca-Cola", 275, STARTING_AMOUNT),
                new Drink("Mountain Dew", 165, STARTING_AMOUNT),
                new Drink("Fanta", 165, 0),
                new Drink("Whiskey?", 200, STARTING_AMOUNT),
            };

            for (int i = 0; i < drinks.Count; i++)
            {
                VendingItems.Add(i+1, drinks[i]);
            };
        }

        public void InsertMoney(int amount)
        {
            if(amount<0)
            {
                Console.Clear();
                Console.WriteLine("An Error has occured");

                money.ReturnFullAmount();
            }

            Console.Clear();
            Console.WriteLine("Adding money to the Machine");
            Task.Delay(1500).Wait();

            DepositedAmount += money.AddMoney(amount);
            Console.WriteLine($"You have ${ConvertToString(DepositedAmount)} remaining");
        }

        public void DisplayItems()
        {
            foreach(KeyValuePair<int, VendingItem> item in VendingItems)
            {
                Console.WriteLine($"{item.Key} - {item.Value.ProductName}: ${ConvertToString(item.Value.Price)}. {item.Value.StockAmount} left");
            }
            Console.WriteLine("Press Enter to Exit");
        }

        public void GetSelectedDrink(ConsoleKeyInfo selection)
        {
            if (selection.Key == ConsoleKey.Enter)
            {
                money.ReturnFullAmount(DepositedAmount);
            }
            int numberSelected = int.Parse(selection.KeyChar.ToString());
            try{
                Console.Clear();
                Console.WriteLine($"Getting {VendingItems[numberSelected].ProductName}");
                Task.Delay(1500).Wait();

                if(VendingItems[numberSelected].Price>DepositedAmount)
                {
                    Console.WriteLine($"Cannot get {VendingItems[numberSelected].ProductName}. Insufficient Funds");
                    money.ReturnFullAmount(DepositedAmount);
                }

                var result = VendingItems[numberSelected].RemoveItem();
                if(result)
                {
                    DepositedAmount -= VendingItems[numberSelected].Price;
                    Dictionary<string, int> change = money.GiveChange(DepositedAmount);

                    if(change["quarter"] == 0 && change["dime"] == 0 && change["nickel"] == 0)
                    {
                        Console.WriteLine("No change to give back");
                    } else {
                        Console.WriteLine($"You get back {change["quarter"]} quarter(s). {change["dime"]} dime(s). {change["nickel"]} nickel(s)");
                    }

                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                } else {
                    Console.WriteLine("");
                    Console.WriteLine($"You have ${ConvertToString(DepositedAmount)} remaining");
                }
            }
            catch{
                Console.Clear();
                Console.WriteLine("An Error has occured");
                money.ReturnFullAmount(DepositedAmount);
            }
        }

        private string ConvertToString(int stringToConvert)
        {
            return string.Format("{0:#.00}", Convert.ToDecimal(stringToConvert)/100);
        }
    }
}