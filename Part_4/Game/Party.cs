


public class Party
{

    public IPlayer Player { get; }
    public List<CharacterBase> Characters { get; } = new List<CharacterBase>();

    /**
     * <summary>
     * Holds a party of characters.
     * </summary>
     * <param name="characters"> Which characters are in the party.</param>
     * <param name="isPlayerParty"> Is player controlled or is computer controlled (true/false) </param>
     */
    public Party(IPlayer player)
    {
       Player = player;
    }

    public int getPartySize()
    {
        if (Characters == null)
        {
            return 0;
        }
        else
        {
            return Characters.Count;
        }
    }



}
