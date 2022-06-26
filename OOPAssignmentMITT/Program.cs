// function call to use vending machine
// accept product price and amount tendered
// calls a function return change to customer and returns a customer greeting message

/*
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



*/



Product coke = new Product("Coke", 2, 322);
Product fanta = new Product("Fanta", 3, 333);

List<int> myMoney = new List<int> { 1, 2 };

CashDrawer vendingMachineFloat = new CashDrawer();
vendingMachineFloat.addCash(10, 5);
vendingMachineFloat.addCash(5, 5);
vendingMachineFloat.addCash(2, 5);
vendingMachineFloat.addCash(1, 5);

VendingMachine myVendingMachine = new VendingMachine();
myVendingMachine.CashDrawer = vendingMachineFloat;
myVendingMachine.addProduct(fanta, 4);
myVendingMachine.addProduct(coke, 3);
myVendingMachine.PurchaseItem(322, myMoney);






class VendingMachine
{
    public int SerialNumber { get; set; } = 1;
    public  CashDrawer CashDrawer { get; set; } 
    public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();

    public VendingMachine()
    {
        SerialNumber = SerialNumber++ ;
        
    }

    public string addProduct(Product product, int number)
    {
        
        if (Inventory.ContainsKey(product))
        {
            Inventory[product] = +number;
        }
        else
        {
            Inventory.Add(product, number);
        }

        return $"{number} {product}s successfully added";

    }

    public string addCash(int bill, int numOfBill)
    {
        int value;
        bool KeyExits = CashDrawer.AvailableCash.TryGetValue(bill, out value);

        if (KeyExits)
        {
            CashDrawer.AvailableCash[bill] = +numOfBill;
        }
        else
        {
            CashDrawer.AvailableCash.Add(bill, numOfBill);
        }

        return $" {numOfBill} {bill} dollar bills added to Cash drawer";


    }

    public string PurchaseItem(int code, List<int> money )
    {
        string machineMessage = "";
        int tenderedAmount = 0;
        int customerChange;

        foreach (int bill in money)
        {
            tenderedAmount =+ bill;
        }

        foreach (KeyValuePair<Product, int> kvp in Inventory)
        {
            if (kvp.Key.Code != code)
            {
                machineMessage = $"Entered incorrect product code";

            }
            else if (tenderedAmount < kvp.Key.Price)
            {
                machineMessage = $"In-sufficient funds. {kvp.Key.Name} cost {kvp.Key.Price} dollars";
            }
            else if (kvp.Value < 1)
            {
                machineMessage = $"Apologies, {kvp.Key.Name} is presently out of stock";
            }
            else if (kvp.Key.Code == code && kvp.Key.Price <= tenderedAmount && kvp.Value > 0)
            {
                Inventory[kvp.Key]--;
                customerChange = tenderedAmount - kvp.Key.Price;
                machineMessage = $"Vending machine dispenses {kvp.Key.Name}. You also have a change of {customerChange}, please wait";               
                tenderChange(customerChange);
            }          

        }

        return machineMessage;
    }

    public string tenderChange(int change)
    {
        int amountToDispense = change;

        foreach(KeyValuePair<int, int> kvp in CashDrawer.AvailableCash) 
        { 
            //needs more work
            if (kvp.Key > change)
            {
                //need to review this to incorporate the dispense cash method on the CashDrawer class
                CashDrawer.AvailableCash[kvp.Key]--;          
                
                amountToDispense =- kvp.Key;
                Console.WriteLine($"Dispenses {kvp.Key} dollars ");
            }
        }
        return $" Transaction complete, Thanks for stopping by";
    }
}

class CashDrawer
{
    public Dictionary<int, int> AvailableCash { get; set; } = new Dictionary<int, int>();

    public void addCash(int bill, int numOfBill)
    {
        AvailableCash.Add(bill, numOfBill);
    }

   
    public void dispenseCash(int bill, int number)
    {
        AvailableCash[bill] =- number;

    }
}


class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public int Code { get; set; }

    public Product(string name , int price, int code)
    {
        Name = name;
        Price = price;
        Code = code;
    }

}