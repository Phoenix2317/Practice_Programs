// See https://aka.ms/new-console-template for more information


Coordinate a = new Coordinate(4, 5);
Coordinate b = new Coordinate(4, 6);
Coordinate c = new Coordinate(3, 6);

Console.WriteLine($"Are a and b adjacent? {Coordinate.AreAdjacent(a, b)}");
Console.WriteLine($"Are a and c adjacent? {Coordinate.AreAdjacent(a, c)}");
Console.WriteLine($"Are b and c adjacent? {Coordinate.AreAdjacent(b, c)}");

// Define a struct to represent a coordinate in a 2D space
public struct Coordinate
{
    //  properties for the X and Y axes
    public int X { get; }
    public int Y { get; }

    /** Initializes a new instance of the Coordinate struct with the specified X and Y values.
     * @param x The X coordinate.
     * @param y The Y coordinate.
     */
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    /** Determines if two coordinates are adjacent to each other.
     * @param a The first coordinate.
     * @param b The second coordinate.
     * @returns True if the coordinates are adjacent; otherwise, false.
     */
    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = Math.Abs(a.X - b.X);
        int colChange = Math.Abs(a.Y - b.Y);
        return ((rowChange <= 1 && colChange == 0) || (rowChange == 0 && colChange <= 1));
    }
}
