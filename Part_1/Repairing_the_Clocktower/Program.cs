// See https://aka.ms/new-console-template for more information
Console.Write("Enter a number for the clock: ");
int input = Convert.ToInt32(Console.ReadLine());

if (input % 2 == 0)
{

    Console.WriteLine("Tick!");

} else
{
    Console.WriteLine("Tock!");
}
