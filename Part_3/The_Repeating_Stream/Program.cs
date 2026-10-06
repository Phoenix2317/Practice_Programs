// See https://aka.ms/new-console-template for more information

RecentNumbers nums = new RecentNumbers { num1 = -1, num2 = -2 };

Thread thread = new Thread(GenrateRandomNumber);

thread.Start(nums);

checkForDuplicates(nums);

/* <summary>
 * This method checks for duplicates in the RecentNumbers object.
 * It runs in an infinite loop, waiting for a key press to check for duplicates.
 * </summary>
 * <param name="nums">The RecentNumbers object to check for duplicates.</param>
 */
void checkForDuplicates(RecentNumbers nums)
{
    while (true)
    {
        Console.ReadKey(false);

        lock (nums)
        {
            if (nums.num1 == nums.num2)
            {
                Console.WriteLine("You found a duplicate.");
            }
            else
            {
                Console.WriteLine("No duplicate found.");
            }

        }
    }
}


/* <summary>
 * This method generates random numbers and updates the RecentNumbers object.
 * </summary>
 * <param name="obj">The RecentNumbers object to update with new random numbers.</param>
 */
void GenrateRandomNumber(object? obj)
{
    if(obj == null || !(obj is RecentNumbers))
    {
        return;
    }

    RecentNumbers nums = (RecentNumbers)obj;

    Random random = new Random();
    while (true)
    {
       int nextnum = random.Next(10);

        lock(nums)
        {
            nums.num2 = nums.num1;
            nums.num1 = nextnum;
        }

        Console.WriteLine(nextnum);
        Thread.Sleep(1000);

    }
    
}


/* <summary>
 * This class represents a pair of recent numbers.
 * It contains two properties: num1 and num2.
 * </summary>
 */
class RecentNumbers
{
   public int num1 { get; set; }
   public int num2 { get; set; }
}

