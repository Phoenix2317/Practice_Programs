public class Game
{

    public Party playerParty { get; private set; }
    public Party enemyParty { get; private set; }
    public bool isGameRunning { get; private set; }
    public bool isGameOver { get; private set; }
    public int playerPartySize { get; private set; }
    public int enemyPartySize { get; private set; }

    public Game(string playerName)
    {
        playerParty = new Party(new CharacterBase[] { new Player(playerName) }, true);
        enemyParty = new Party(new CharacterBase[] { new Skeleton() }, false);
        isGameRunning = false;
        isGameOver = false;
        playerPartySize = playerParty.getPartySize();
        enemyPartySize = enemyParty.getPartySize();
    }

    public void Start()
    {
        Console.WriteLine("The battle begins!");
        isGameRunning = true;
    }

    public void getParty(Party party)
    {
        if(party.Characters == null || party.Characters.Length == 0)
        {
            Console.WriteLine("The party has no characters.");
            return;
        }
        else
        {
            
            foreach(var character in party.Characters)
            {
                Console.WriteLine($"Character: {character.name}, Is Player: {character.isPlayer}");
            }

        }
        
    }

    public void displayParty(Party party)
    {
        if (party.Characters == null || party.Characters.Length == 0)
        {
            Console.WriteLine("The party has been defeated.");
            return;
        }
        else
        {
            Console.WriteLine($"Party Members ({party.getPartySize()}):");
            for (int i = 0; i < party.getPartySize(); i++)
            {
                Console.WriteLine($" 1. {party.Characters[i].name}");
            }
        }
    }
}
