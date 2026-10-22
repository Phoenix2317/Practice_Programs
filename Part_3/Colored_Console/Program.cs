using Colored;

string? name = ColoredConsole.Prompt("Enter your name: ");
ColoredConsole.WriteLine($"Hello, {name}!", ConsoleColor.Green);
ColoredConsole.Write("Welcome to the show!", ConsoleColor.Yellow);
Console.WriteLine();
