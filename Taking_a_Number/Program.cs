// See https://aka.ms/new-console-template for more information


/// <summary>
/// Displays the given text on the console and returns the entered number
/// </summary>
int AskForNumber(string text)
{

    Console.WriteLine(text);
    int num = Convert.ToInt32(Console.ReadLine());
    return num;

}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {

        Console.WriteLine(text);
        int num = Convert.ToInt32(Console.ReadLine());

        if(num >= min && num <= max)
        {
            return num;
        } else
        {
            Console.WriteLine("That value is out of range.");
        }

    }
    

}
