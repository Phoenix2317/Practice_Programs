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

        if(!game.Run())
        {
            Console.WriteLine("Game over.");
        } else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Another Battle begins!");

            Enemyparty = new Party(new ComputerPlayer());
            Enemyparty.Characters.Add(new Skeleton());
            Enemyparty.Characters.Add(new Skeleton());

            game = new Game(Playerparty, Enemyparty);

            if(!game.Run())
            {
                Console.WriteLine("Game over.");
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Final Battle begins!");
                Enemyparty = new Party(new ComputerPlayer());
                Enemyparty.Characters.Add(new UncodedOne());
                game = new Game(Playerparty, Enemyparty);
                if (!game.Run())
                {
                    Console.WriteLine("Game over.");
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Congratulations! You have defeated all enemies!");
                }
            }
    }
}


