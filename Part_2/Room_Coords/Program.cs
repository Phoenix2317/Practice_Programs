// See https://aka.ms/new-console-template for more information


Coordinate a = new Coordinate(4, 5);
Coordinate b = new Coordinate(4, 6);
Coordinate c = new Coordinate(3, 6);

Console.WriteLine($"Are a and b adjacent? {Coordinate.AreAdjacent(a, b)}");
Console.WriteLine($"Are a and c adjacent? {Coordinate.AreAdjacent(a, c)}");
Console.WriteLine($"Are b and c adjacent? {Coordinate.AreAdjacent(b, c)}");

public struct Coordinate
{
    public int X { get; }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = Math.Abs(a.X - b.X);
        int colChange = Math.Abs(a.Y - b.Y);
        return ((rowChange <= 1 && colChange == 0) || (rowChange == 0 && colChange <= 1));
    }
}
