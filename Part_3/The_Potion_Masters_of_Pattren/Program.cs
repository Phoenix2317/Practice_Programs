// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the alchemy shop!");
Console.WriteLine("You can make one potion here for free, ruining a potion judt makes you start over.");

var potion = new Potion(PotionType.water);

// Runs until the user ends
while (true)
{

    //displays the result of the potion
    Console.WriteLine('\n' + Result(potion));

    PotionType result = potion.potion;

    if(result == PotionType.ruined)
    {
        result = PotionType.water;
        Console.WriteLine("Cauldron has been dumped and filled with water.");
    }

    display();

    Console.Write("What do you want to add? (Enter the number of your choice): ");
    int choice = Convert.ToInt32(Console.ReadLine());
    
    //ends the program if user enters 6
    if (choice == 6)
    {
        Console.WriteLine("Thanks for stopping by, Have a good day!");
        break;
    }

    IngredientType ingredient = (IngredientType)choice;

    //Takes the previous potion and mixes it with a new ingredient for a new result
    switch (result, ingredient)
    {
        case (PotionType.water, IngredientType.stardust):
            potion = new Potion(PotionType.elixir);
            break;
        case (PotionType.elixir, IngredientType.snakeVenom):
            potion = new Potion(PotionType.poison);
            break;
        case (PotionType.elixir, IngredientType.dragonBreath):
            potion = new Potion(PotionType.flying);
            break;
        case (PotionType.elixir, IngredientType.shadowGlass):
            potion = new Potion(PotionType.invisibility);
            break;
        case (PotionType.elixir, IngredientType.eyeshine):
            potion = new Potion(PotionType.nightSight);
            break;
        case (PotionType.nightSight, IngredientType.shadowGlass):
        case (PotionType.invisibility, IngredientType.eyeshine):
            potion = new Potion(PotionType.cloudyBrew);
            break;
        case (PotionType.cloudyBrew, IngredientType.stardust):
            potion = new Potion(PotionType.wraith);
            break;
        default:
            potion = new Potion(PotionType.ruined); 
            break;       
    }
    

}

/// <summary>
/// A menu for the user to choose from
/// </summary>
void display()
{
  
    Console.WriteLine("Possible ingrediants to add: ");
    Console.WriteLine("1.       Stardust");
    Console.WriteLine("2.    Snake Venom");
    Console.WriteLine("3.  Dragon Breath");
    Console.WriteLine("4.   Shadow Glass");
    Console.WriteLine("5.   Eyeshine Gem");
    Console.WriteLine("6. Finish brewing");

}

/// <summary>
/// A method for taking the potion and analysing the effects
/// </summary>
string Result(Potion potion)
{
    return potion switch
    {
        Potion { potion: PotionType.water } => "Just water in a bottle, the starting point",
        Potion { potion: PotionType.elixir } => "A magic bottle of Elixir brimming with potential, just needs a guide.",
        Potion { potion: PotionType.poison } => "A deadly bottle of poison.",
        Potion { potion: PotionType.flying } => "A potion of flight, a child's long awaited dream.",
        Potion { potion: PotionType.invisibility } => "A potion of invisibility, though it feels like it can still change...",
        Potion { potion: PotionType.nightSight } => "A potion of Night Sight, though it feels like it can still change...",
        Potion { potion: PotionType.cloudyBrew } => "A cloudy bottle, the magic inside mixing and waiting for a catalyst to fuse together.",
        Potion { potion: PotionType.wraith } => "A potent Wraith potion, don't get consumed by the rage boiling within.",
        _ => "A ruined bottle, have to start over."

    };
}

/// <summary>
/// The class holding the result of the potion
/// </summary>
/// <param name="potion">
/// The current effect of the potion
/// </param>
public record Potion(PotionType potion);


/// <summary>
/// What type of potion has been made
/// </summary>
public enum PotionType { water, elixir, poison, flying, invisibility, nightSight, cloudyBrew, wraith, ruined};
/// <summary>
/// What ingredient to add to the potion
/// </summary>
public enum IngredientType {water, stardust, snakeVenom, dragonBreath, shadowGlass, eyeshine };
