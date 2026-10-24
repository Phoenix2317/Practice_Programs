internal class Program
{
    private static void Main(string[] args)
    {

        Game game = new Game();

        game.playerParty.Characters = new CharacterBase[] { new Player("Hero"), new Skeleton() };
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

            Thread.Sleep(500);
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
    public Player(string name)
    {
        this.name = name;
        this.isPlayer = true;
    }

}

public class Skeleton : CharacterBase
{
    public Skeleton()
    {
        this.name = "Skeleton";
        this.isPlayer = false;
    }
}

public class Party
{
    
    public CharacterBase[] Characters { get; set; }
    public bool isPlayerParty { get; set; }
    public bool isDefeated { get; set; }

}
