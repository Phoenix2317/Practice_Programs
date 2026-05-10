// See https://aka.ms/new-console-template for more information

Pack storage = new Pack(50f, 20f, 10);

Console.WriteLine($"A pack has been created with  a weight limit of {storage.maxWeight} a volume limit of {storage.maxVolume} and a item limit of {storage.InvSize}");

while (true)
{

    Console.WriteLine(storage.ToString());

    Console.WriteLine("What do you want to add?");
    Console.WriteLine("1 - Arrow ");
    Console.WriteLine("2 - Bow ");
    Console.WriteLine("3 - Rope ");
    Console.WriteLine("4 - Water ");
    Console.WriteLine("5 - Food Rations");
    Console.WriteLine("6 - Sword ");
    

    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRations(),
        6 => new Sword()
    };

    if (!storage.Add(newItem))
    {
        Console.WriteLine("Unable to put item in inventory");
    }

    Console.WriteLine();
    Console.WriteLine($"Volume: {storage.CurrVolume}\n Weight: {storage.CurrWeight}\n Items: {storage.Count}\n");
    
}

public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
    public InventoryItem() 
    {
        Weight = 0f;
        Volume = 0f;
    }
    
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString()
    {
        return "Arrow";
    }

}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
    public override string ToString()
    {
        return "Bow";
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
        public override string ToString()
        {
            return "Rope";
    }
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
        public override string ToString()
        {
            return "Water";
    }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, 0.5f) { }
        public override string ToString()
        {
            return "Food Rations";
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
        public override string ToString()
        {
            return "Sword";
    }
}

public class Pack
{
    public float maxWeight { get; private set; }
    public float maxVolume { get; private set; }

    public int InvSize { get; private set; }
    private InventoryItem[] Inventory;
    public int Count { get; private set; }
    public float CurrWeight { get; private set; }
    public float CurrVolume { get; private set; }

    public Pack(float maxweight, float maxvolume, int invsize)
    {
        maxWeight = maxweight;
        maxVolume = maxvolume;
        Count = 0;
        CurrWeight = 0f;
        CurrVolume = 0f;
        Inventory = new InventoryItem[invsize];
        InvSize = invsize;

    }

    public bool Add(InventoryItem item)
    {
        if (Count >= InvSize) return false;
        else if (CurrVolume + item.Volume > maxVolume) return false;
        else if (CurrWeight + item.Weight  > maxWeight) return false;
        else
        {
            Inventory[Count] = item;
            Count++;
            CurrVolume += item.Volume;
            CurrWeight += item.Weight;
            return true;
        }
    }

    public override string ToString()
    {
        string output = $"Pack with {Count} items, {CurrWeight} weight and {CurrVolume} space\n";
        for (int i = 0; i < Count; i++)
        {
            
            output += Inventory[i].ToString();
            if (i < Count - 1)
            {
                output += ", ";
            }
        }
        return output;
    }
}