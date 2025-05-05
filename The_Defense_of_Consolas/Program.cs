// See https://aka.ms/new-console-template for more information
Console.Title = "Defense of Consolas";
Console.Write("Target Row? ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Target Column? ");
int column = Convert.ToInt32(Console.ReadLine());
int up = row + 1;
int down = row - 1;
int left = column - 1; 
int right = column + 1;
Console.WriteLine("Deploy to: ");
//(row, column)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"({row}, {left})");
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine($"({down}, {column})");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"({row}, {right})");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"({up}, {column})");
Console.ForegroundColor = ConsoleColor.White;
Console.Beep();
