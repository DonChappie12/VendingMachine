using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Money
    {
        private int quarter = 25;
        private int dime = 10;
        private int nickel = 5;
        private int total;
        
        public int AddMoney(int money)
        {
            total = 0;
            return total+=money*100;
        }

        public Dictionary<string, int> GiveChange(int returningChange)
        {
            Dictionary<string, int> change = new Dictionary<string, int>()
            {
                {"quarter", 0},
                {"dime", 0},
                {"nickel", 0}
            };
            
            total = returningChange;
            if(total > 0)
            {
                Console.WriteLine("Dispensing Change");
                Task.Delay(2500).Wait();
                while(total > 0)
                {
                    if(total >= quarter)
                    {
                        change["quarter"]++;
                        RemoveMoneyBy(quarter);
                    } else if(total >= dime){
                        change["dime"]++;
                        RemoveMoneyBy(dime);
                    } else if(total >= nickel){
                        change["nickel"]++;
                        RemoveMoneyBy(nickel);
                    } else {
                        break;
                    }
                }
            }

            return change;
        }

        public void RemoveMoneyBy(int money)
        {
            if (money <= 0)
            {
                Console.WriteLine("No money to dispense");
            } else {
                total -= money;
            }
        }

        public void ReturnFullAmount(int amount = 0)
        {
            Console.WriteLine("Dispensing Change");
            Task.Delay(1500).Wait();
            if(amount == 0)
            {
                Console.WriteLine("No money to return");
            }
            else{
                Console.WriteLine($"Returning ${string.Format("{0:#.00}", Convert.ToDecimal(amount)/100)}");
            }

            Task.Delay(1500).Wait();
            Console.WriteLine("Self Destructing");
            Environment.Exit(0);
        }
    }
}