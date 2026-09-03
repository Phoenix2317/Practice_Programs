
Random oatmeal = new Random();

int bad = oatmeal.Next(10);

List<int> chosen = new List<int>();

while (true)
{
    Console.WriteLine("Pick a number from 0-9:");
    int guess = int.Parse(Console.ReadLine());

    try
    {
        if (guess != bad && !chosen.Contains(guess))
        {
            Console.WriteLine("Yay! That was a chocolate cookie!");
            chosen.Add(guess);
        }
        else if (chosen.Contains(guess))
        {
            Console.WriteLine("That number has already been taken. Try again.");

        }
        else
        {
            throw new CookieException("Yuck! You got the oatmeal raisn cookie! You lose!");
        }
    } catch (CookieException e)
    {
        Console.WriteLine(e.Message);
        break;
        
    } finally
    {
        chosen.Clear();
        
    }

}

public class  CookieException : Exception
{
    public CookieException() { }
    public CookieException(string message) : base(message) { }
}
