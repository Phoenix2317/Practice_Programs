// See https://aka.ms/new-console-template for more information


// Create a new map with dimensions 4x4 and initialize the player's starting coordinate at (0, 0)
Map mapF = new Map(4, 4);
Coordinate playerCoordinate = new Coordinate(0, 0);

// Start the main game loop
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
    
   

    Console.WriteLine("Enter your action (N, S, E, W, ENABLE): ");

    string action = Console.ReadLine().ToUpper(); // Read the player's action and convert it to uppercase for consistency

    IActionCommand movement = action switch // Determine the appropriate command based on the player's input
    {
        "N" => new NorthCommand(),
        "S" => new SouthCommand(),
        "E" => new EastCommand(),
        "W" => new WestCommand(),
        "ENABLE" => new EnableCommand(),
        _ => new InvalidCommand() // Handle invalid commands
    };

    movement.Run(ref playerCoordinate, mapF); // Execute the command, passing the player's coordinate and the map

}


// Class representing the map of the game
public class Map
{
    // Properties for the map's dimensions
    public int Width { get; }
    public int Height { get; }
    public int MaxWidth { get; }
    public int MaxHeight { get; }

    // Property for the fountain's location on the map
    public Coordinate fountainLocation { get; } = new Coordinate(0, 2);
    public bool FountainEnabled { get; set; } = false;

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
public class  EnableCommand : IActionCommand
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


