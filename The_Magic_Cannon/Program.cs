// See https://aka.ms/new-console-template for more information
Console.WriteLine("Let's start cranking!");

for (int i = 0; i < 100; i++)
{
    if ((i + 1) % 3 == 0 && (i + 1) % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{(i + 1)}:  Omega blast!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if ((i + 1) % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{(i + 1)}:  Fire blast!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if ((i + 1) % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{(i + 1)}:  Electric Blast!");
        Console.ForegroundColor = ConsoleColor.White;
    } else
    {
        Console.WriteLine($"{(i + 1)}:  Normal strike");
    }
}