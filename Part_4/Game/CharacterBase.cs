public class CharacterBase
{
    public bool isPlayer { get; protected set; }

    public string name { get; protected set; }

    public virtual void Action()
    {
        Console.WriteLine($"{name} is staring...");
    }
}