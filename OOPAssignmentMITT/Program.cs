// function call to use vending machine
// accept product price and amount tendered
// calls a function return change to customer and returns a customer greeting message

string useVendingMachine(int productCost, int amountTendered)
{
    int customerChange = amountTendered - productCost;
    string machineOutput = "";

    if (customerChange > 0)
    {
        Console.WriteLine("Please collect your merchandise");
        machineOutput = string.Format("Please Wait, Dispensing {0} Dollars", customerChange);

    }
    else if (customerChange < 0)
    {
        machineOutput = string.Format("You have not tendered enough money for this merchandise");
    }

    // Still to decipher how to delay this function call with a set timeout kinda thing
    Console.WriteLine(tenderCustomerChange(customerChange));


    return machineOutput;
}

// accepts amount to return to customer
// from available dispenser drawer returns change customer

string tenderCustomerChange(int customerChange)
{
    Dictionary<int, int> vendingMachineCashDrawer = new Dictionary<int, int>();

    vendingMachineCashDrawer.Add(20, 1);
    vendingMachineCashDrawer.Add(10, 15);
    vendingMachineCashDrawer.Add(5, 15);
    vendingMachineCashDrawer.Add(2, 15);
    vendingMachineCashDrawer.Add(1, 15);

    int amountToDispense = customerChange;

    int[] dollarBills = new int[] { 20, 10, 5, 2, 1 };

    foreach (int dollar in dollarBills)
    {
        while (amountToDispense > dollar & vendingMachineCashDrawer[dollar] > 0)
        {
            amountToDispense = amountToDispense - dollar;
            vendingMachineCashDrawer[dollar] = vendingMachineCashDrawer[dollar] - 1;
            Console.WriteLine(dollar + " bills dispensed");
        }

    }

    return "Thanks for your patronage, Enjoy the rest of your day";
}

Console.WriteLine(useVendingMachine(1, 50));





class VendingMachine
{
    public int serialNumber { get; set; } = 0;
    public  ICollection<CashDrawer> cashDrawer { get; set; } 
}

class CashDrawer
{
    public Dictionary<int, int> availableCash { get; set; } = new Dictionary<int, int>();

    public void addCash(int bill, int number)
    {
        availableCash.Add(bill, number);

        Console.WriteLine("{0} {1} dollar bills added to Cash Drawer", number, bill);
    }

    public void dispenseCash(int bill, int number)
    {
        availableCash[bill] =- number;

        Console.WriteLine("{0} {1} dollar bills dispensed", number, bill);
    }
}

class MachineInventory
{

}