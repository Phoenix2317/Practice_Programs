/** <summary>
 * Represents an enemy character in the game.
 * </summary>
 */


public class Party
{
    
    /**
     * <summary>
     * Holds a party of characters.
     * </summary>
     * <param name="characters"> Which characters are in the party.</param>
     * <param name="isPlayerParty"> Is player controlled or is computer controlled (true/false) </param>
     */
    public Party(CharacterBase[] characters, bool isPlayerParty)
    {
        Characters = characters;
        this.isPlayerParty = isPlayerParty;
        isDefeated = false;
    }

    public CharacterBase[] Characters { get; private set; }

    public bool isPlayerParty { get;}
    public bool isDefeated { get;}


    public int getPartySize()
    {
        if (Characters == null)
        {
            return 0;
        }
        else
        {
            return Characters.Length;
        }
    }



}
