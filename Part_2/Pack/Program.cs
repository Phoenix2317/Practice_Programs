// See https://aka.ms/new-console-template for more information


Pack storage = new Pack(50f, 20f, 10);

Console.WriteLine($"A pack has been created with  a weight limit of {storage.maxWeight} a volume limit of {storage.maxVolume} and a item limit of {storage.InvSize}");

// Start the main loop to interact with the inventory system
while (true)
{
    // Display the current state of the inventory
    Console.WriteLine(storage.ToString());

    // Prompt the user to choose an item to add to the inventory
    Console.WriteLine("What do you want to add?");
    Console.WriteLine("1 - Arrow ");
    Console.WriteLine("2 - Bow ");
    Console.WriteLine("3 - Rope ");
    Console.WriteLine("4 - Water ");
    Console.WriteLine("5 - Food Rations");
    Console.WriteLine("6 - Sword ");
    

    int choice = Convert.ToInt32(Console.ReadLine());

    // Create a new inventory item based on the user's choice using a switch expression
    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRations(),
        6 => new Sword()
    };

    // Attempt to add the new item to the inventory and display a message if it fails
    if (!storage.Add(newItem))
    {
        Console.WriteLine("Unable to put item in inventory");
    }

    // Display the current state of the inventory after attempting to add the item
    Console.WriteLine();
    Console.WriteLine($"Volume: {storage.CurrVolume}\n Weight: {storage.CurrWeight}\n Items: {storage.Count}\n");
    
}

// Define the base class for inventory items with properties for weight and volume
public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    /**
     * Initializes a new instance of the InventoryItem class with the specified weight and volume.
     * @param weight The weight of the inventory item.
     * @param volume The volume of the inventory item.
     */
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }

    /**
     * Initializes a new instance of the InventoryItem class with default weight and volume values.
     */
    public InventoryItem() 
    {
        Weight = 0f;
        Volume = 0f;
    }
    
}

// Define specific inventory item classes that inherit from InventoryItem and provide their own weight and volume values
public class Arrow : InventoryItem
{
    // Initializes a new instance of the Arrow class with specific weight and volume values.
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString()
    {
        return "Arrow";
    }

}

public class Bow : InventoryItem
{
    // Initializes a new instance of the Bow class with specific weight and volume values.
    public Bow() : base(1f, 4f) { }
    public override string ToString()
    {
        return "Bow";
    }
}

public class Rope : InventoryItem
{
    // Initializes a new instance of the Rope class with specific weight and volume values.
    public Rope() : base(1f, 1.5f) { }
    public override string ToString()
    {
        return "Rope";
    }
}

public class Water : InventoryItem
{
    // Initializes a new instance of the Water class with specific weight and volume values.
    public Water() : base(2f, 3f) { }
    public override string ToString()
    {
        return "Water";
    }
}

public class FoodRations : InventoryItem
{
    // Initializes a new instance of the FoodRations class with specific weight and volume values.
    public FoodRations() : base(1f, 0.5f) { }
    public override string ToString()
    {
        return "Food Rations";
    }
}

public class Sword : InventoryItem
{
    // Initializes a new instance of the Sword class with specific weight and volume values.
    public Sword() : base(5f, 3f) { }
    public override string ToString()
    {
        return "Sword";
    }
}

// Define the Pack class that represents a collection of inventory items with weight and volume constraints
public class Pack
{
    // Properties to hold the maximum weight and volume limits of the pack
    public float maxWeight { get; private set; }
    public float maxVolume { get; private set; }

    // Property to hold the maximum number of items that can be stored in the pack
    public int InvSize { get; private set; }

    private InventoryItem[] Inventory;

    // Properties to hold the current count of items, current weight, and current volume of the pack
    public int Count { get; private set; }
    public float CurrWeight { get; private set; }
    public float CurrVolume { get; private set; }

    /**
     * Initializes a new instance of the Pack class with the specified maximum weight, maximum volume, and inventory size.
     * @param maxweight The maximum weight limit of the pack.
     * @param maxvolume The maximum volume limit of the pack.
     * @param invsize The maximum number of items that can be stored in the pack.
     */
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

    /**
     * Attempts to add an inventory item to the pack.
     * @param item The inventory item to be added.
     * @returns True if the item was successfully added; otherwise, false.
     */
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

    /**
     * Returns a string representation of the pack, including its current state and the items it contains.
     * @returns A string representation of the pack.
     */
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