// See https://aka.ms/new-console-template for more information
namespace BoardGame;

public class Game
{
    //Number of players for the game
    public int NumPlayers { get; private set; }


    //Number of players for the game
    public Game(int Players)
    {
        NumPlayers = Players;
        
    }

   
}
