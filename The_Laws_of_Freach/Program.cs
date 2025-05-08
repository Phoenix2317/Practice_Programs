// See https://aka.ms/new-console-template for more information
int[] numbers = new int[10] {12, 34, 63, 13, 3, 452, 95, -9, 122, 1 };


int min = int.MaxValue;
float total = 0;
//i is the value, not an index. it does not work for numbers[i]
//it works for value = i though.
foreach (int i in numbers)
{
    if (i < min)
    {
        min = i;
    }

    total += i;
}

float average = total / numbers.Length;

Console.WriteLine("Done!");
Console.WriteLine($"{min} is the smallest number");
Console.WriteLine($"The avergae of the group is {average}");

