// See https://aka.ms/new-console-template for more information
Console.WriteLine("Number of avaible chocolate eggs: ");
int eggs = Convert.ToInt32(Console.ReadLine());
int sisters = 4;
Console.WriteLine("Number of eggs the sisters each get: " + (eggs / sisters));
Console.WriteLine("Number of eggs the duckbear gets: " + (eggs % sisters));
if(eggs % sisters > eggs / sisters)
{
    Console.WriteLine("The duckBear gets more eggs then the sisters");
}
else
{
    Console.WriteLine("The sisters get more eggs then the duck bear");
}
