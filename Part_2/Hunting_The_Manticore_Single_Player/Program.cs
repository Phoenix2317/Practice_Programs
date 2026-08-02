


//int location = AskForNumberInRange("Player 1 Choose the location of the Manticore (1 to 100): ", 1, 100);
//int health = 15;
//int enemy = 10;
//int shot = 1;
bool run = true;
int target;

Game game = new Game(0);

Console.WriteLine("1 or 2 players? (1 for 1 player, 2 for 2 players)");

int playerCount = Convert.ToInt32(Console.ReadLine());



if (playerCount == 1)
{
    PlayerComputer computerPlayer = new PlayerComputer();
    int location = computerPlayer.TakeTurn(ref game);
    game.TargetLocation = location;

}
else if (playerCount == 2)
{
    Player1 player1 = new Player1();
    int location = player1.TakeTurn(ref game); 
    game.TargetLocation = location;
}

Console.Clear();

Player2 player2 = new Player2();

Console.WriteLine("Player 2, its time to fire!");

while (run)
{
    target = player2.TakeTurn(ref game);
    short check = game.roundCheck();
    if (target == game.TargetLocation)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        switch (check)
        {
            case 1:
                game.EnemyHealth -= 3;
                Console.WriteLine("Direct hit! The Manticore's hull is scorched!");
                break;
            case 2:
                game.EnemyHealth -= 3;
                Console.WriteLine("Direct hit! The Manticore's sails are ripped by the electricity!");
                break;
            case 3:
                game.EnemyHealth -= 10;
                Console.WriteLine("Kaboom! That was a direct hit blasting the Manticore apart!");
                break;
            default:
                game.EnemyHealth -= 1;
                Console.WriteLine("Direct hit! Parts of the ship got scattered!");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;

    }
    else if (target > game.TargetLocation)
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

    if (game.EnemyHealth > 0)
    {

        Console.WriteLine("The Manticore has fired! One of the buildings has been destroyed!");
        game.Health -= 1;

    }

    if (game.EnemyHealth <= 0)
    {

        run = false;
        Console.WriteLine("The Manticore has been destroyed! The city is safe!");

    }
    else if (game.Health <= 0)
    {
        run = false;
        Console.WriteLine("The Magic Cannon was destroyed by the attack! The city is lost!");
        Console.WriteLine("The Manticore was located at: " + game.TargetLocation);

    }

    game.ShotNumber++;


}

public class Game
{
    public int Health { get; set; } = 15;
    public int EnemyHealth { get; set; } = 10;
    public int ShotNumber { get; set; } = 1;
    public int TargetLocation { get; set; }
    public Game(int targetLocation)
    {
        TargetLocation = targetLocation;
    }

    public void status()
    {
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"Status: Round: {ShotNumber} City: {Health}/15 Manticore: {EnemyHealth}/10");

        short check = roundCheck();

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
    /// Displays the current health of the city and manticore as well as the current damage type
    /// </summary>


    /// <summary>
    /// Checks to see if anything special happens this turn
    /// </summary>
    public short roundCheck()
    {

        if (ShotNumber % 3 == 0 && ShotNumber % 5 == 0)
        {

            return 3;

        }
        else if (ShotNumber % 5 == 0)
        {
            return 2;
        }
        else if (ShotNumber % 3 == 0)
        {

            return 1;

        }
        else
        {
            return 0;
        }

    }

    /// <summary>
    /// Takes a number from a certain range value
    /// </summary>
    public int AskForNumberInRange(string text, int min, int max)
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

}




public interface Iplayer
{
    int TakeTurn(ref Game game);
}

public class Player1 : Iplayer
{
    public int TakeTurn(ref Game game)
    {
        int location = game.AskForNumberInRange("Player 1 Choose the location of the Manticore (1 to 100): ", 1, 100);
       
        return location; 
    }
}

public class Player2 : Iplayer
{
    public int TakeTurn(ref Game game)
    {
        game.status();
        int target = game.AskForNumberInRange("Enter desired range, the Manticore is located between 1 and 100: ", 1, 100);
        return target;
    }
}

public class PlayerComputer : Iplayer
{
    public int TakeTurn(ref Game game)
    {
        Random rand = new Random();
        int location = rand.Next(0, 100) + 1;
        return location;
    }
}