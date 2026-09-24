// See https://aka.ms/new-console-template for more information

BlockCoordinate startLoc = new BlockCoordinate(0, 0);
BlockOffset offset = new BlockOffset(1, 2);
Direction direction = Direction.North;

Console.WriteLine($"Welcome to operand city! Your current location is: {startLoc[0]}, {startLoc[1]}");
Console.WriteLine("Let's head south first!");

startLoc = startLoc + Direction.South;

Console.WriteLine($"Now we are at: {startLoc[0]}, {startLoc[1]}");
Console.WriteLine("Now to move Southeast.");

startLoc = startLoc + new BlockOffset(4, 9);

Console.WriteLine($"Now we are at: {startLoc[0]}, {startLoc[1]}");
Console.WriteLine("Hmm, we seem to have moved to far east. Lets go back a bit.");

startLoc = startLoc + new BlockOffset(0, -4);

Console.WriteLine($"Now we are at: {startLoc[0]}, {startLoc[1]}");
Console.WriteLine("Thanks for exploring Operand City!");

public record BlockCoordinate(int Row, int Column)
{
    
    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            else if (index == 1) return Column;
            else throw new ArgumentOutOfRangeException(nameof(index), index, null);
        }
    }

    public static BlockCoordinate operator +(BlockCoordinate start, BlockOffset end) => new BlockCoordinate(start.Row + end.RowOffset, start.Column + end.ColumnOffset);
    public static BlockCoordinate operator +(BlockOffset end, BlockCoordinate start) => start + end;

    public static BlockCoordinate operator +(BlockCoordinate start, Direction direction) => direction switch
    {
        Direction.North => new BlockCoordinate(start.Row - 1, start.Column),
        Direction.East => new BlockCoordinate(start.Row, start.Column + 1),
        Direction.South => new BlockCoordinate(start.Row + 1, start.Column),
        Direction.West => new BlockCoordinate(start.Row, start.Column - 1),
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
    public static BlockCoordinate operator +(Direction direction, BlockCoordinate start) => start + direction;

    
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }