//Start with Dictionary and shopping list

//Dictionary
Dictionary<string, decimal> menu = new Dictionary<string, decimal>()
{
    ["apple"] = 0.99m,
    ["onion"] = 0.59m,
    ["cauliflower"] = 1.59m,
    ["avocado"] = 2.19m,
    ["pretzels"] = 1.59m,
    ["chocolate"] = 2.09m,
    ["orange juice"] = 3.29m,
    ["salami"] = 4.49m,
};

//Shopping list
List<string> foodList = new List<string>();
List<decimal> priceList = new List<decimal>();

//Welcome and display menu
Console.WriteLine("Welcome to the Art's Mart!");
Console.WriteLine(String.Format("{0,-12} {1,12}", "Item", "Price"));
Console.WriteLine("=============================");
foreach (KeyValuePair<string, decimal> item in menu) //key is first element value is second
{
    Console.WriteLine(String.Format("{0,-12} {1,12}", item.Key, $"${item.Value}"));
}

bool looping = true;
while (looping)
{
    //prompt user
    Console.WriteLine("What item would you like to order?");
    string order = Console.ReadLine().ToLower().Trim();

    //add item and price to respective lists
    if (menu.ContainsKey(order))
    {
        Console.WriteLine($"Adding {order} to cart at {menu[order]}");
        foodList.Add(order);
        priceList.Add(menu[order]);

        //continue?
        while (true)
        {
            Console.WriteLine("Would you like to order anything else? y/n");
            string more = Console.ReadLine().ToLower().Trim();
            if (more == "y")
            {
                looping = true;
                break;
            }
            else if (more == "n")
            {
                looping = false;
                break;
            }
            else
            {
                Console.WriteLine("Sorry, that was not an option.");
            }
        }
    }
    else
    {
        Console.WriteLine("Sorry, we don't carry those");
    }
}
Console.WriteLine();
Console.WriteLine("Thanks for your order!");
Console.WriteLine("Here is what you got:");
Console.WriteLine();

//for loop to display totals
for (int i = 0; i < foodList.Count; i++)
{
    Console.WriteLine("{0,-12} {1,12}", foodList[i] , priceList[i]);
}

//total
double bill = priceList.Sum();
Console.WriteLine($"Your total order runs up to ${bill}");

//Average
Console.WriteLine($"The average price per item in your order was ${Math.Round(bill / priceList.Count)}");