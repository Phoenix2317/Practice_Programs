internal class Program
{
    private static void Main(string[] args)
    {
        string? playerName; 
        Game game = new Game();

        do
        {
            Console.Write("Enter your character's name: ");
            playerName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(playerName));


        game.playerParty.Characters = new CharacterBase[] { new Player(playerName)};
        game.enemyParty.Characters = new CharacterBase[] { new Skeleton() };
        game.Start();

        while(!game.isGameOver)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player's Turn!");

            foreach (var character in game.playerParty.Characters)
            {
                Console.WriteLine($"{character.name}'s Turn!");
                character.Action();
                Console.WriteLine();
            }

            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemy's Turn!");
            
            foreach(var character in game.enemyParty.Characters)
            {
                Console.WriteLine($"{character.name}'s Turn!");
                character.Action();
                Console.WriteLine();
            }

            
        }
    }
}

public class Game
{

    public Party playerParty { get; set; }
    public Party enemyParty { get; set; }
    public bool isGameRunning { get; private set; }
    public bool isGameOver { get; private set; }

    public Game()
    {
        playerParty = new Party();
        enemyParty = new Party();
        isGameRunning = false;
        isGameOver = false;
    }

    public void Start()
    {
        Console.WriteLine("The battle begins!");
        isGameRunning = true;
    }
}

public class Player : CharacterBase
{
    string? input = null;
    int actionNumber = 0;
    public Player(string name)
    {
        this.name = name;
        this.isPlayer = true;
    }

    public override void Action()
    {
        Console.WriteLine($"{name} is deciding what to do...");
        displayActionMenu();
        do
        {
            input = Console.ReadLine();
            if (int.TryParse(input, out int actionNumber) && actionNumber >= 1 && actionNumber <= 3)
            {
                ActionType selectedAction = (ActionType)(actionNumber - 1);

                if(selectedAction == ActionType.DoNothing)
                {
                    Console.WriteLine($"{name} is doing nothing...");
                }
                else if (selectedAction == ActionType.Attack)
                {
                    Console.WriteLine($"{name} is attacking!");
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
        } while(!int.TryParse(input, out _) || actionNumber < 1 || actionNumber > 3);

    }

    private void displayActionMenu()
    {
        Console.WriteLine("Choose an action:");
        Console.WriteLine(" 1. Do Nothing");
        Console.WriteLine(" 2. Attack");
        Console.WriteLine(" 3. Use Item");
    }

}

public class Skeleton : CharacterBase
{
    public Skeleton()
    {
        this.name = "Skeleton";
        this.isPlayer = false;
    }

    public override void Action()
    {
        Console.WriteLine($"{name} is doing nothing...");
    }
}

public class Party
{
    
    public CharacterBase[] Characters { get; set; }
    public bool isPlayerParty { get; set; }
    public bool isDefeated { get; set; }

}
