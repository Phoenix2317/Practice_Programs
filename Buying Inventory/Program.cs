// See https://aka.ms/new-console-template for more information
Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");
Console.Write("What's the number of the item you want: ");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("Rope is 10 gold pieces.");
        break;
    case 2:
        Console.WriteLine("Torches are 15 gold pieces.");
        break;
    case 3:
        Console.WriteLine("Climbing Equipment is 25 gold pieces.");
        break;
    case 4:
        Console.WriteLine("Clean Water is 1 gold piece.");
        break;
    case 5:
        Console.WriteLine("A machete is 20 gold pieces.");
        break;
    case 6:
        Console.WriteLine("A Canoe is 200 gold pieces.");
        break;
    case 7:
        Console.WriteLine("Food Supplies are 1 gold piece.");
        break;
    default:
        Console.WriteLine("What!? You think we carry everything!?");
        break;
}
