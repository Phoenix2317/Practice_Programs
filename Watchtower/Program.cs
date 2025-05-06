// See https://aka.ms/new-console-template for more information
Console.Write("What is the x direction of the enemy? ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("What is the y direction of the enemy? ");
int y = Convert.ToInt32(Console.ReadLine());
//West
if (x < 0)
{

    if (y < 0)
    {
        Console.WriteLine("Enemy to the Southwest!");
    }
    else if (y > 0)
    {
        Console.WriteLine("Enemy to the Northwest!");
    }
    else if (y == 0)
    {
        Console.WriteLine("Enemy to the West!");
    }
}
//east
else if (x > 0)
{

    if (y < 0)
    {
        Console.WriteLine("Enemy to the Southeast!");
    }
    else if (y > 0)
    {
        Console.WriteLine("Enemy to the Northeast!");
    }
    else if (y == 0)
    {
        Console.WriteLine("Enemy to the East!");
    }
} 
//North\South
else
{

    if (y < 0)
    {
        Console.WriteLine("Enemy to the South!");
    }
    else if (y > 0)
    {
        Console.WriteLine("Enemy to the North!");
    }
    else if (y == 0)
    {
        Console.WriteLine("An enemy is here!");
    }

}
