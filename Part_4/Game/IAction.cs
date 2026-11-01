public interface IAction
{
    void Run(Game game, CharacterBase actor);
}

public record AttackData(int Damage);

public interface IAttack
{
    string name { get; }
    AttackData Create();
}

public class BoneCrunch : IAttack
{
    private static readonly Random random = new Random();
    public string name { get; } = "Bone Crunch";
    public AttackData Create() => new AttackData(random.Next(2)); // Damage between 0 and 1

}

public class DoNothingAction : IAction
{
    public void Run(Game game, CharacterBase actor)
    {
        Console.WriteLine($"{actor.Name} is doing nothing...");
    }
}

public class Punch : IAttack
{
    public string name { get; } = "Punch";
    public AttackData Create() => new AttackData(1); 
}

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private readonly CharacterBase _target;

    public AttackAction(IAttack attack, CharacterBase target)
    {

       _attack = attack;
       _target = target;
    }
    public void Run(Game game, CharacterBase actor)
    {
        Console.WriteLine($"{actor.Name} uses {_attack.name} on {_target.Name}!");
        
        AttackData data = _attack.Create();
        _target.CurrentHealth -= data.Damage;

        Console.WriteLine($"{_attack.name} deals {data.Damage} damage to {_target.Name}!");
        Console.WriteLine($"{_target.Name} has {_target.CurrentHealth} health remaining out of {_target.MaxHealth}.");
        if(_target.CurrentHealth <= 0)
        {
            Console.WriteLine($"{_target.Name} has been defeated!");
            game.GetPartyFor(_target).Characters.Remove(_target);
        }
    }
}