CharberryTree tree = new CharberryTree();

Notifier notice = new Notifier(tree);
Harvest harvest = new Harvest(tree);

while (true)
{
    tree.MaybeGrow();
   
}

public class  CharberryTree
{

    public event Action? Ripened; //Makes an event that can be subscribed to by other classes
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke(); //Triggers the event and listeners
        }
    }


}

public class  Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened; //Subscribes to the Ripened event
    }

    private void OnRipened() // Is triggered when the Ripened event is Triggered
    {
        Console.WriteLine("The charberry tree has ripened!");
    }
}

public class Harvest
{
    public int _harvestCount { get; private set; }
    private CharberryTree _tree;
    public Harvest(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnRipened; // Also subscribes to the Ripened event
    }
    private void OnRipened() //Is triggered at the same time as the Notifier class when the Ripened event is triggered
    {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"Harvested charberries! Total harvest count: {_harvestCount}");
    }
}
