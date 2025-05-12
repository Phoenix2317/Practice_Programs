internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bread is ready!");
        Console.WriteLine("Who is this bread for?");
        string name = Console.ReadLine();
        Console.WriteLine("Noted, Here is your bread " + name);
    }
}