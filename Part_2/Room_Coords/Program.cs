// See https://aka.ms/new-console-template for more information


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
