using System.Runtime.CompilerServices;

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
       
        List<CharacterBase> targets = game.GetEnemypartyFor(actor).Characters;
        if(targets.Count > 0)
        {
            return new AttackAction(actor.Basic, game.GetEnemypartyFor(actor).Characters[0]);
        }
        return new DoNothingAction();
    }
}

public class HumanPlayer : IPlayer
{
    public IAction ChooseAction(Game game, CharacterBase actor)
    {
        List<MenuChoice> menuChoices = CreateMenuOptions(game, actor);

        for(int i = 0; i < menuChoices.Count; i++)
        {
            
            Console.WriteLine($"{i + 1}. {menuChoices[i].Description}", menuChoices[i].Enabled ? Console.ForegroundColor = ConsoleColor.Gray : Console.ForegroundColor = ConsoleColor.DarkGray);
        }


        Console.WriteLine("What will you do?: ");
        string choice = Console.ReadLine() ?? "";
        int menuIndex = Convert.ToInt32(choice) - 1;

        if (menuChoices[menuIndex].Enabled)
        {
            return menuChoices[menuIndex].Action!;
        }
       

        return new DoNothingAction();

    }
    private List<MenuChoice> CreateMenuOptions(Game game, CharacterBase actor)
    {
        Party currentParty = game.GetPartyFor(actor);
        Party otherParty = game.GetEnemypartyFor(actor);

        List<MenuChoice> menuChoices = new List<MenuChoice>();
        
        if(otherParty.Characters.Count > 0)
        {
           menuChoices.Add(new MenuChoice($"Standard Attack ({actor.Basic.name})", new AttackAction(actor.Basic, otherParty.Characters[0])));
        }
        else
        {
            menuChoices.Add(new MenuChoice($"Standard Attack ({actor.Basic.name})", null));
        }

        menuChoices.Add(new MenuChoice("Do Nothing", new DoNothingAction()));

        return menuChoices;
    }
}



public record MenuChoice(string Description, IAction? Action)
{
    public bool Enabled => Action != null;
}