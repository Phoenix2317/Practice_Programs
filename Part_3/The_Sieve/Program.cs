
Console.Write("What makes a good number? (1 = evens, 2 = positives, 3 = Multiples of Ten): ");
int choice = Convert.ToInt32(Console.ReadLine());


/**
 * Switches which Delegate Sieve will use
 */
Sieve sieve = choice switch 
{
    1 => new Sieve(isEven),
    2 => new Sieve(isPositive),
    3 => new Sieve(isTen)
};

while (true)
{

    Console.Write("Please enter a number: ");
    int num = Convert.ToInt32(Console.ReadLine());
    string badOrGood = sieve.IsGood(num) ? "Good" : "Bad";
    Console.WriteLine($"That number is {badOrGood}");

}

/**
 * Takes a number and compares if it is even or not
 */
bool isEven(int num) => num % 2 == 0;
/**
 * Takes a number and compares if it is positive
 */
bool isPositive(int num) => num > 0;
/**
 * Takes a number and compares if it can easily divide into ten
 */
bool isTen(int num) => num % 10 == 0;

/**
 * A class designed to tell if an inputted number is
 * A good number or a bad number using delegates to decide which is which
 */
public class Sieve
{

    private Func<int, bool> _desc;

    public Sieve(Func<int, bool> desc) => _desc = desc;

    public bool IsGood(int num)
    {
        return _desc(num);
    }

}
