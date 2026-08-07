// See https://aka.ms/new-console-template for more information


// Create a new map with dimensions 4x4 and initialize the player's starting coordinate at (0, 0)
Map mapF = new Map(4, 4);
Coordinate playerCoordinate = new Coordinate(0, 0);

// Start the main game loop

IActionCommand start = new HelpCommand(); // Create a new instance of the HelpCommand to display the game instructions

DateTime startDateTime = DateTime.Now;
DateTime endDateTime = DateTime.Now;

start.Run(ref playerCoordinate);

while (true)
{

    Console.WriteLine("-------------------------------"); // Separator for clarity

    Console.WriteLine($"You are at ({playerCoordinate.X}, {playerCoordinate.Y})."); // Display the player's current coordinates

    if (playerCoordinate.X == 0 && playerCoordinate.Y == 0) // Check if the player is at the entrance of the cave
    {
        if (!mapF.FountainEnabled) // Check if the fountain is not enabled
        {
            Console.WriteLine("You can see light from the entrance of the cave.");
        }
        else
        {
            Console.WriteLine("The fountain of Objects has been reactivated! You escaped with your life!");
            Console.WriteLine("You have won the game!");
            endDateTime = DateTime.Now;
            break; // Exit the loop and end the game
        }
    }
    else if (mapF.IsFountainCoordinate(playerCoordinate)) // Check if the player is at the fountain's location
    {
        
        if (mapF.FountainEnabled) // Check if the fountain is enabled
        {
            Console.WriteLine("You hear the rushing waters from the fountain of Objects. It had been reactivated!");
        }
        else
        {
            Console.WriteLine("You hear water dripping in the room. The fountain of Objects is here!");
        }
    } 
    else if (mapF.isPitNearby(playerCoordinate)) // Check if the player is near the pit's location
    {
        Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
    }
    else if (mapF.IsPitCoordinate(playerCoordinate)) // Check if the player is at the pit's location
    {
        Console.WriteLine("You fell into a pit and died! Game over.");
        endDateTime = DateTime.Now;
        break; // Exit the loop and end the game
    }
    else // If the player is in any other room
    {
        Console.WriteLine("You are in a dark room. You can hear water dripping.");
    }



    Console.WriteLine("Enter your action (N, S, E, W, ENABLE): ");

    string action = Console.ReadLine().ToUpper(); // Read the player's action and convert it to uppercase for consistency

    IActionCommand movement = action switch // Determine the appropriate command based on the player's input
    {
        "N" => new NorthCommand(),
        "S" => new SouthCommand(),
        "E" => new EastCommand(),
        "W" => new WestCommand(),
        "ENABLE" => new EnableCommand(),
        "HELP" => new HelpCommand(),
        _ => new InvalidCommand() // Handle invalid commands
    };

    movement.Run(ref playerCoordinate, mapF); // Execute the command, passing the player's coordinate and the map

}

TimeSpan time = endDateTime - startDateTime;

Console.WriteLine($"You were in the cave for {time.Minutes} minuets and {time.Seconds} seconds.");


// Class representing the map of the game
public class Map
{
    // Properties for the map's dimensions
    public int Width { get; }
    public int Height { get; }
    public int MaxWidth { get; }
    public int MaxHeight { get; }

    // Property for the fountain's location on the map
    public Coordinate fountainLocation { get; } = new Coordinate(3, 2);
    public bool FountainEnabled { get; set; } = false;

    public Coordinate pitLocation { get; } = new Coordinate(2,3);

    // Constructor to initialize the map with specified width and height
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        MaxWidth = width;
        MaxHeight = height;

    }

    // Method to check if a given coordinate is valid within the map's boundaries
    public bool IsValidCoordinate(Coordinate coordinate)
    {
        if (coordinate.X < 0 || coordinate.X >= MaxWidth || coordinate.Y < 0 || coordinate.Y >= MaxHeight)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Method to check if a given coordinate matches the fountain's location
    public bool IsFountainCoordinate(Coordinate coordinate)
    {
        if (coordinate.X == fountainLocation.X && coordinate.Y == fountainLocation.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPitCoordinate(Coordinate coordinate)
    {
        if (coordinate.X == pitLocation.X && coordinate.Y == pitLocation.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isPitNearby(Coordinate coordinate)
    {
        // Check the four adjacent coordinates (north, south, east, west) for the pit's location
        Coordinate north = new Coordinate(coordinate.X - 1, coordinate.Y);
        Coordinate south = new Coordinate(coordinate.X + 1, coordinate.Y);
        Coordinate east = new Coordinate(coordinate.X, coordinate.Y + 1);
        Coordinate west = new Coordinate(coordinate.X, coordinate.Y - 1);
        return IsPitCoordinate(north) || IsPitCoordinate(south) || IsPitCoordinate(east) || IsPitCoordinate(west);
    }
}


// Struct representing a coordinate on the map
public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Interface for action commands that can be executed on a coordinate
public interface IActionCommand
{
    void Run(ref Coordinate cord, Map? map = null);
    
}

// Class representing the command to move north
public class NorthCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        cord.X = cord.X - 1;
    }
}

// Class representing the command to move south
public class SouthCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        cord.X = cord.X + 1;
    }
}

// Class representing the command to move east
public class EastCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        cord.Y = cord.Y + 1;
    }
}

// Class representing the command to move west
public class WestCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        cord.Y = cord.Y - 1;
    }
}


// Class representing the command to enable or disable the fountain
public class EnableCommand : IActionCommand
{
   public void Run(ref Coordinate cord, Map? map = null)
    {

        if (map != null) // Check if the map is not null
        {
            if (map.IsFountainCoordinate(cord)) // Check if the player's coordinate matches the fountain's location
            {
                map.FountainEnabled = !map.FountainEnabled; // Toggle the fountain's enabled state
            } 
            else
            {
                Console.WriteLine("The fountain is not in this room."); // Inform the player that they are not at the fountain's location
            }
            
        } 
        else 
        { 
            Console.WriteLine("Map is null."); // Inform the player that the map is null, which should not happen in normal gameplay
        }
    }
}

// Class representing an invalid command entered by the player
public class InvalidCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        Console.WriteLine("Invalid command. Please enter a valid action (N, S, E, W, ENABLE).");
    }
}

public class HelpCommand : IActionCommand
{
    public void Run(ref Coordinate cord, Map? map = null)
    {
        Console.WriteLine("-------------------------------");

        Console.WriteLine("You enter the Cavern of objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.");
        Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
        Console.WriteLine("You must navigate the caverns with your other senses, like hearing and touch.");
        Console.WriteLine("Find the Fountain of Objects, Activate it, and return to the Entrance.");

        Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room.");
        Console.WriteLine("If you enter a room with a pit, you will die.");

        Console.WriteLine();

        Console.WriteLine("Available commands:");
        Console.WriteLine("N - Move North");
        Console.WriteLine("S - Move South");
        Console.WriteLine("E - Move East");
        Console.WriteLine("W - Move West");
        Console.WriteLine("ENABLE - Enable or disable the fountain if you are in the same room as the fountain.");
        Console.WriteLine("HELP - Display this help message.");
    }
}

