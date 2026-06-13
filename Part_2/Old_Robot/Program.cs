

Robot robot = new Robot();


for (int i = 0; i < 3; i++)
{
    string call = Console.ReadLine();
    robot.Commands[i] = call switch
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
robot.Run();



public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X}, {Y}, {IsPowered}]");
        }
    }
}
public interface  IRobotCommand 
{
    void Run(Robot robot);
}

public class  OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
 
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





