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

        Console.WriteLine("Game mode selection: ");
        Console.WriteLine("1. Player vs Computer");
        Console.WriteLine("2. Computer vs Computer");
        Console.WriteLine("3. Player vs Player");
        Console.WriteLine("What mode do you want?: ");
        string choice = Console.ReadLine() ?? "";

        IPlayer player1, player2;
        
        if(choice == "1")
        {
            player1 = new HumanPlayer();
            player2 = new ComputerPlayer();
        }
        else if (choice == "2")
        {
            player1 = new ComputerPlayer();
            player2 = new ComputerPlayer();
        }
        else
        {
            player1 = new HumanPlayer();
            player2 = new HumanPlayer();
        }
        

        Party Playerparty = new Party(player1);
        Playerparty.Characters.Add(new Player(playerName));

        Party Enemyparty = new Party(player2);
        Enemyparty.Characters.Add(new Skeleton());

        Game game = new Game(Playerparty, Enemyparty);

        if (!game.Run())
        {
            Console.WriteLine("Game over.");
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Another Battle begins!");

            Enemyparty = new Party(new ComputerPlayer());
            Enemyparty.Characters.Add(new Skeleton());
            Enemyparty.Characters.Add(new Skeleton());

            game = new Game(Playerparty, Enemyparty);

            if (!game.Run())
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
}


