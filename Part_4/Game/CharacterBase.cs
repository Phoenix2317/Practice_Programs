public abstract class CharacterBase
{
    

    public abstract string Name { get; protected set; }

    public abstract IAttack Basic { get; }
    public int MaxHealth { get; }

    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Math.Clamp(value, 0, MaxHealth);
    }

    public CharacterBase(int hp)
    {
        MaxHealth = hp;
        CurrentHealth = hp;
    }

}

public interface IPlayer
{
    IAction ChooseAction(Game game, CharacterBase actor);
}

public class Skeleton : CharacterBase
{
    public override string Name { get; protected set; } = "Skeleton";
    public override IAttack Basic { get; } = new BoneCrunch();
    public Skeleton() : base(5)
    {
    }
}

public class UncodedOne : CharacterBase
{
    public override string Name { get; protected set; } = "The Uncoded One";
    public override IAttack Basic { get; } = new BoneCrunch();
    public UncodedOne() : base(15)
    {
    }
}

public class Player : CharacterBase
{
    public override string Name { get; protected set; }
    public override IAttack Basic { get; } = new Punch();
    public Player(string name) : base(10)
    {
        Name = name;
    }
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Game game, CharacterBase actor)
    {

        Thread.Sleep(1000);
        // Simple AI: always attack the first enemy
       
        
        return new AttackAction(actor.Basic, game.GetEnemypartyFor(actor).Characters[0]);
        
       
    }
}
