// See https://aka.ms/new-console-template for more information

Console.WriteLine("Please Insert Dollar cash amount to begin");

string? cash = Console.ReadLine();

VendingMachine.Models.VendingMachine vm = new VendingMachine.Models.VendingMachine();

vm.InsertMoney(int.Parse(cash));

while(true)
{

    Console.WriteLine("Please Select from the following Menu");
    vm.DisplayItems();
    
    ConsoleKeyInfo selected = Console.ReadKey();
    vm.GetSelectedDrink(selected);
}
