namespace Colored
{
    public class ColoredConsole
    {
        public static string? Prompt(string prompt)
        {
            Console.Write(prompt);
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine();
        }

        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
