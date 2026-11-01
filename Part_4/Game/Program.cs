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

        Party Playerparty = new Party(new ComputerPlayer());
        Playerparty.Characters.Add(new Player(playerName));

        Party Enemyparty = new Party(new ComputerPlayer());
        Enemyparty.Characters.Add(new Skeleton());

        Game game = new Game(Playerparty, Enemyparty);
        game.Run();

        
    }
}


