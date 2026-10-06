// See https://aka.ms/new-console-template for more information


Console.WriteLine("Enter a word to randomly recreate: ");
string? word = Console.ReadLine();
DateTime start = DateTime.Now;
int attempts = await RandomlyRecreateAsynch(word);

Console.WriteLine($"It took {attempts} attempts to randomly recreate the word '{word}'");
TimeSpan elapsed = DateTime.Now - start;
Console.WriteLine($"Elapsed time: {elapsed.TotalSeconds} seconds");

/** <summary>
 * Randomly recreates the given word by generating random strings of the same length until it matches the original word.
 * </summary>
 * <params name="word">The word to be recreated.</params>
 * <returns>The number of attempts it took to recreate the word.</returns>
 */
int RandomlyRecreate(string? word)
{

    if(string.IsNullOrEmpty(word))
    {
        return 0;
    }
    int length = word.Length;
    word = word.ToLower();
    string recreatedWord;
    int count = 0;

    Random random = new Random();
    
    do
    {
        count++;
        recreatedWord = "";
        for (int i = 0; i < length; i++)
        {
            recreatedWord += (char)('a' + random.Next(26));
        }
    } while (recreatedWord != word);


    return count;
}

/** <summary>
 * Asynchronously randomly recreates the given word by generating random strings of the same length until it matches the original word.
 * </summary>
 * <params name="word">The word to be recreated.</params>
 * <returns>A task that represents the asynchronous operation. The task result contains the number of attempts it took to recreate the word.</returns>
 */
Task<int> RandomlyRecreateAsynch(string? word)
{
    return Task.Run(() => RandomlyRecreate(word));
}
