// See https://aka.ms/new-console-template for more information

int[] nums = {1,9,2,8,3,7,4,6,5};

Console.WriteLine("Original numbers: " + string.Join(", ", nums));
Console.WriteLine("After processing with normal code: " + string.Join(", ", sort(nums)));
Console.WriteLine("After processing with Keywords: " + string.Join(", ", sortKey(nums)));
Console.WriteLine("After processing with Method syntax: " + string.Join(", ", sortMethod(nums)));

/** <summary>
 * Sorts the input sequence by filtering even numbers, sorting them, and doubling each. using simple code
 * </summary>
 * <param name="input">The input sequence of integers.</param>
 * <returns>The sorted and doubled sequence of even numbers.</returns>
 */
IEnumerable<int> sort(IEnumerable<int> input)
{

    List<int> filtered = new List<int>();

    foreach(int num in input)
    {
        if (num % 2 == 0)
        {
            
            filtered.Add(num);
        }
    }
   

    int[] result = filtered.ToArray();
    Array.Sort(result);

    for(int i = 0; i < result.Length; i++)
    {
        result[i] *= 2;
    }

    return result;

}

/** <summary>
 * Sorts the input sequence by filtering even numbers, sorting them, and doubling each using a keyword search method.
 * </summary>
 * <param name="input">The input sequence of integers.</param>
 * <returns>The sorted and doubled sequence of even numbers.</returns>
 */
IEnumerable<int> sortKey(IEnumerable<int> input)
{
    return from num in input
           where num % 2 == 0
           orderby num
           select num * 2;
}

/** <summary>
 * Sorts the input sequence by filtering even numbers, sorting them, and doubling each using method syntax.
 * </summary>
 * <param name="input">The input sequence of integers.</param>
 * <returns>The sorted and doubled sequence of even numbers.</returns>
 */
IEnumerable<int> sortMethod(IEnumerable<int> input)
{
    return input.Where(num => num % 2 == 0)
                .OrderBy(num => num)
                .Select(num => num * 2);
}

// The first method is the most messy code wise, Though it allows for fine tuning.
// The second method is more compact and is faster, as it doesn't keep the entire list in memory, harder to fine tune.
// The third list is the same as the second one, just using methods so it is more likely to catch any errors that occur before causing a crash.