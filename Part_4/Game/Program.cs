internal class Program
{
    private static void Main(string[] args)
    {
        string? playerName; 
        

        do
        {
            Console.Write("Enter your character's name: ");
            playerName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(playerName));

        Game game = new Game(playerName);
        
        game.Start();

        while(!game.isGameOver)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player's Turn!");

            for(int i = 0; i < game.playerParty.getPartySize(); i++)
            {
                Console.WriteLine($"{game.playerParty.Characters[i].name}'s Turn!");
                game.playerParty.Characters[i].Action(game);
                Console.WriteLine();
            }

            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemy's Turn!");
            
            for(int i = 0; i < game.enemyParty.getPartySize(); i++)
            {
                Console.WriteLine($"{game.enemyParty.Characters[i].name}'s Turn!");
                game.enemyParty.Characters[i].Action(game);
                Console.WriteLine();
            }

            
        }
    }
}

// <summary>
// Represents a player character in the game.
// </summary>
public class Player : CharacterBase
{
    string? input = null;
    int actionNumber = 0;
    public Player(string name)
    {
        this.name = name;
        this.isPlayer = true;
    }

    // <summary>
    // Executes the player's action during the game turn.
    // </summary>
    // <param name="game">The game instance.</param>
    public override void Action(Game game)
    {
        Console.WriteLine($"{name} is deciding what to do...");
        displayActionMenu();


        while (true)
        {
            input = Console.ReadLine();
            if (int.TryParse(input, out int actionNumber) && actionNumber >= 1 && actionNumber <= 3)
            {
                ActionType selectedAction = (ActionType)(actionNumber - 1);

                if (selectedAction == ActionType.DoNothing)
                {
                    Console.WriteLine($"{name} is doing nothing...");
                }
                else if (selectedAction == ActionType.Attack)
                {
                    while (true)
                    {
                        game.displayParty(game.enemyParty);
                        Console.Write("Choose a target to attack (enter the number): ");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out int targetNumber) && targetNumber >= 1 && targetNumber <= game.enemyParty.getPartySize())
                        {
                            Console.WriteLine($"{name} is attacking {game.enemyParty.Characters[targetNumber - 1].name}!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid target selection.");
                        }
                    }
                }
                else if (selectedAction == ActionType.UseItem)
                {
                    Console.WriteLine($"{name} is using an item...");
                }


                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }


        }
    }

    private void displayActionMenu()
    {
        Console.WriteLine("Choose an action:");
        Console.WriteLine(" 1. Do Nothing");
        Console.WriteLine(" 2. Attack");
        Console.WriteLine(" 3. Use Item");
    }

}

// <summary>
// Represents an enemy character in the game.
// </summary>
public class Skeleton : CharacterBase
{
    public Skeleton()
    {
        this.name = "Skeleton";
        this.isPlayer = false;
    }

    public override void Action(Game game)
    {
        Console.WriteLine($"{name} used Bone Crunch on {game.playerParty.Characters[0].name}!");
    }
}
