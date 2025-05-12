// See https://aka.ms/new-console-template for more information

int location = AskForNumberInRange("Player 1 Choose the location of the Manticore (1 to 100): ", 1, 100);
int health = 15;
int enemy = 10;
int shot = 1;
bool run = true;
int target;
Console.Clear();

Console.WriteLine("Player 2, its time to fire!");

while (run)
{
    status(health, shot, enemy);
    target = AskForNumberInRange("Enter desired range, the Manticore is located between 1 and 100: ", 1, 100);
    short check = roundCheck(shot);
    if(target == location)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        switch (check)
        {
            case 1:
                enemy -= 3;
                Console.WriteLine("Direct hit! The Manticore's hull is scorched!");
                break;
            case 2: 
                enemy -= 3;
                Console.WriteLine("Direct hit! The Manticore's sails are ripped by the electricity!");
                break;
            case 3:
                enemy -= 10;
                Console.WriteLine("Kaboom! That was a direct hit blasting the Manticore apart!");
                break;
            default:
                enemy -= 1;
                Console.WriteLine("Direct hit! Parts of the ship got scattered!");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;

    } else if(target > location)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Overshot! Try to aim lower next time!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The shot fell short! Try to aim higher next time!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    if (enemy > 0)
    {

        Console.WriteLine("The Manticore has fired! One of the buildings has been destroyed!");
        health -= 1;

    } 
    
    if (enemy <= 0) 
    {  

        run = false;
        Console.WriteLine("The Manticore has been destroyed! The city is safe!");
    
    } 
    else if (health <= 0)
    {
        run = false;
        Console.WriteLine("The Magic Cannon was destroyed by the attack! The city is lost!");

    }

    shot++;

    
}


/// <summary>
/// Displays the current health of the city and manticore as well as the current damage type
/// </summary>
void status(int health, int shot, int enemy)
{
    Console.WriteLine("------------------------------------------------------------");
    Console.WriteLine($"Status: Round: {shot} City: {health}/15 Manticore: {enemy}/10");

    short check = roundCheck(shot);

    switch (check)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("The fire crystal is blazing! ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This shot will deal 3 points of damage!");
            break;
        case 2: 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("The electric crystal is crackling! ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This shot will deal 3 points of damage!");
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Both crystals are full of energy, Omega blast is prepared!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This shot will deal 10 points of damage, make it count!");
            break;
        default:
            Console.WriteLine("This shot will deal 1 point of damage.");
            break;
    }

}

/// <summary>
/// Checks to see if anything special happens this turn
/// </summary>
short roundCheck(int shot)
{

    if (shot % 3 == 0 && shot % 5 == 0)
    {

        return 3;

    }
    else if (shot % 5 == 0)
    {
        return 2;
    }
    else if (shot % 3 == 0) 
    {
    
        return 1;
    
    } else
    {
        return 0;
    }

}

/// <summary>
/// Takes a number from a certain range value
/// </summary>
int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {

        Console.Write(text);
        int num = Convert.ToInt32(Console.ReadLine());

        if (num >= min && num <= max)
        {
            return num;
        }
        else
        {
            Console.WriteLine("That value is out of range.");
        }

    }


}
