// See https://aka.ms/new-console-template for more information
int[] initial = new int[5];

for (int i = 0; i < 5; i++)
{
    Console.Write("Enter a value: ");
    initial[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Replicating...");

//copies the entire array. Can do [0..2] to copy the values at 0 and 1 but not 2
int[] copy = initial[0..];

Console.WriteLine("Done! Displaying now.");

for (int i = 0; i < copy.Length; i++)
{
    Console.WriteLine(copy[i]);
}
