public class Game
{

    public Party playerParty { get; private set; }
    public Party enemyParty { get; private set; }
   

    public Game(Party playerParty, Party enemyParty)
    {
        this.playerParty = playerParty;
        this.enemyParty = enemyParty;
    }
    

    public void Run()
    {
        Console.WriteLine("The battle begins!");

        while (true)
        {

            foreach (Party party in new[] { playerParty, enemyParty })
            {
                foreach (CharacterBase character in party.Characters)
                {
                    Console.WriteLine();

                    if(GetPartyFor(character) == playerParty)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"{character.Name}'s turn!");
                    party.Player.ChooseAction(this, character).Run(this, character);
                }
            }
        }
    }

    public Party GetEnemypartyFor(CharacterBase character) => playerParty.Characters.Contains(character) ? enemyParty : playerParty;
    public Party GetPartyFor(CharacterBase character) => playerParty.Characters.Contains(character) ? playerParty : enemyParty;
}
