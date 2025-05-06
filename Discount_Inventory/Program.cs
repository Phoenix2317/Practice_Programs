// See https://aka.ms/new-console-template for more information
//Menu
Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

//Choice from menu
Console.Write("What's the number of the item you want: ");
int choice = Convert.ToInt32(Console.ReadLine());
//Name of Buyer
Console.Write("What's your name? ");
string name = Console.ReadLine();

//Item chosen
string item = choice switch
{

    1 => "Rope",
    2 => "Torches",
    3 => "Climbing Equipment",
    4 => "Clean Water",
    5 => "Machete",
    6 => "Canoe",
    7 => "Food Supplies",
    _ => "Not Avaible"

};

//Price of item
int price = item switch
{

    "Rope" => 10,
    "Torches" => 15,
    "Climbing Equipment" => 25,
    "Clean Water" => 1,
    "Machete" => 20,
    "Canoe" => 200,
    "Food Supplies" => 1,
    _ => -1

};

//Discount given
double discount = name switch
{

    "KB" => 0.5,
    _ => 1

};

//Final cost
Console.WriteLine($"{item} Costs {price * discount}");
