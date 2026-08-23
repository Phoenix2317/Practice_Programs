
while (true)
{
    Console.Write("Please enter an Int: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int value))
    {
        Console.WriteLine($"You entered: {value}");
        break;
    }
    else
    {
        Console.WriteLine("That is not a number!");
    }
}
while (true)
{
    Console.Write("Enter a decimal: ");
    string? input = Console.ReadLine();
    if(double.TryParse(input, out double value))
    {
        Console.WriteLine($"You entered: {value}");
        break;
    } else
    {
        Console.WriteLine("That is not valid!");
    }
}
while (true)
{
    Console.Write("True or False: ");
    string? input = Console.ReadLine();
    if(bool.TryParse(input, out bool value))
    {
        string result = value ? "true" : "false";
        Console.WriteLine($"That is {result}");
        break;
    } else
    {
        Console.WriteLine("That is not valid!");
    }
}
