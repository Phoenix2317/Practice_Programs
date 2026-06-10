

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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X}, {Y}, {IsPowered}]");
        }
    }
}
public abstract class RobotCommand 
{
    public abstract void Run(Robot robot);
}

public class  OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
 
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y += 1;
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}





