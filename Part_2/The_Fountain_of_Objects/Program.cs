// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class Map
{
    public int Width { get; }
    public int Height { get; }
    public int MaxWidth { get; }
    public int MaxHeight { get; }

    public Coordinate fountainLocation { get; } = new Coordinate(0, 2);
    public bool FountainEnabled { get; set; } = false;

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        MaxWidth = width;
        MaxHeight = height;

    }
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

public interface IActionCommand
{
    void Run(Coordinate cord);
}

public class NorthCommand : IActionCommand
{
    public void Run(Coordinate cord)
    {
        cord.X = cord.X - 1;
    }
}

public class SouthCommand : IActionCommand
{
    public void Run(Coordinate cord)
    {
        cord.X = cord.X + 1;
    }
}

public class EastCommand : IActionCommand
{
    public void Run(Coordinate cord)
    {
        cord.Y = cord.Y + 1;
    }
}

public class WestCommand : IActionCommand
{
    public void Run(Coordinate cord)
    {
        cord.Y = cord.Y - 1;
    }
}

public class  EnableCommand : IActionCommand
{
   
}

