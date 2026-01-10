// See https://aka.ms/new-console-template for more information


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
    
}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, 0.5f) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
}

public class Pack
{
    public float maxWeight { get; private set; }
    public float maxVolume { get; private set; }

    private InventoryItem[] Inventory;
    public int Count { get; private set; }
    public float CurrWeight { get; private set; }
    public float CurrVolume { get; private set; }

    public Pack()
    {
        maxWeight = 20f;
        maxVolume = 10f;
        Count = 0;
        CurrWeight = 0f;
        CurrVolume = 0f;
        Inventory = new InventoryItem[50];
    }

    public bool Add(InventoryItem item)
    {
        if (Count == 50) return false;
        else if (!Check(item)) return false;
        else
        {
            Inventory[Count] = item;
            Count++;
            return true;
        }
    }

    private bool Check(InventoryItem newItem)
    {
        foreach (InventoryItem item in Inventory)
        {
            CurrWeight += item.Weight;
            CurrVolume += item.Volume;
        }

        CurrWeight += newItem.Weight;
        CurrVolume += newItem.Volume;

        if (CurrVolume > maxVolume || CurrWeight > maxWeight)
        {
            CurrWeight -= newItem.Weight;
            CurrVolume -= newItem.Volume;
            return false;
            
        } else
        {
           
            return true;
        }
    }
}