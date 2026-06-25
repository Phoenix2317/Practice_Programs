

Robot robot = new Robot();

// Read three commands from the console and assign them to the robot's Commands array
for (int i = 0; i < 3; i++)
{
    string call = Console.ReadLine();
    robot.Commands[i] = call switch // Use a switch expression to map the input string to the corresponding command object
    {
        "ON" => new OnCommand(),
        "OFF" => new OffCommand(),
        "NORTH" => new NorthCommand(),
        "SOUTH" => new SouthCommand(),
        "EAST" => new EastCommand(),
        "WEST" => new WestCommand(),
        _ => null
    };
}
robot.Run(); // Execute the commands assigned to the robot and display its state after each command


// Class representing the robot with its properties and methods
public class Robot
{
    // Properties to hold the robot's coordinates and power state
    public int X { get; set; }
    public int Y { get; set; }

    public bool IsPowered { get; set; }

    // Array to hold the commands for the robot
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    // Method to execute the commands in the Commands array
    public void Run()
    {
        // Iterate through each command in the Commands array
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X}, {Y}, {IsPowered}]");
        }
    }
}

// Interface defining the contract for robot commands
public interface  IRobotCommand 
{
    void Run(Robot robot);
}

// Command class to turn the robot on
public class  OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

// Command class to turn the robot off
public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

// Command class to move the robot north
public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y += 1;
        }
    }
}

// Command class to move the robot south
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}

// Command class to move the robot east
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}

// Command class to move the robot west
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}





