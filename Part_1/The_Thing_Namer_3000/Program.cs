internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("What kind of thing are we talking about?");
        //name of thing
        string a = Console.ReadLine();
        Console.WriteLine("How would you describe it? Big? Azure? Tattered?");

        /* Description of the thing */
        string b = Console.ReadLine();
        string c = "of Doom"; //Adding dangerous vibes
        string d = "3000"; //Not the first of its kind
        Console.WriteLine("The " + b + " " + a + c + " " + d + "!");
    }
}