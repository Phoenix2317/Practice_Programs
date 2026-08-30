
Random ran = new Random();

Console.WriteLine(ran.NextDouble(100));
Console.WriteLine(ran.NextString("Yip", "Yap", "Yop"));
Console.WriteLine(ran.CoinFlip());
Console.WriteLine(ran.CoinFlip(0.75));

public static class RandomExtensions
{
    /**
     * Picks a number from 0 to maxVal
     *
     */
    public static double NextDouble(this Random r, double maxVal)
    {
        double result = 0;

        result = r.NextDouble();

        result = maxVal * result;

        return result;
    }


    /**
     * Picks a random string that is passed to it as an array
     */
    public static string NextString(this Random r, params string[] wordsLs)
    {
        int choice = r.Next(wordsLs.Length);
        
        return wordsLs[choice];
    }
    /**
     * Flips a coin, allowing you to change the chance of heads appearing
     */
    public static bool CoinFlip(this Random r, double chanceH = 0.5)
    {

        double coin = r.NextDouble();

        if (coin < chanceH)
        {
            return false;

        } else
        {
            return true;
        }
    }

}
