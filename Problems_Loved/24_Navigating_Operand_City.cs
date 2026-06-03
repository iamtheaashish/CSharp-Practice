BlockCoordinate blockCoordinate = new BlockCoordinate(4,3);
BlockOffset blockOffset = new BlockOffset(2,0);
Direction direction = Direction.East;

BlockCoordinate newCoordinate = blockCoordinate + blockOffset;
Console.WriteLine($"{newCoordinate.Row}, {newCoordinate.Column}");

BlockCoordinate newnewCoordinate = blockCoordinate + direction;
Console.WriteLine($"{newnewCoordinate.Row}, {newnewCoordinate.Column}");

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate x, BlockOffset y) =>
                                new BlockCoordinate(x.Row + y.RowOffset, x.Column + y.ColumnOffset);
    
    public static BlockCoordinate operator +(BlockCoordinate x, Direction y)
    {
        return y switch
        {
            Direction.North => new BlockCoordinate(x.Row - 1, x.Column),
            Direction.East => new BlockCoordinate(x.Row, x.Column + 1),
            Direction.South => new BlockCoordinate(x.Row + 1, x.Column),
            Direction.West => new BlockCoordinate(x.Row, x.Column - 1),
            _      => new BlockCoordinate(x.Row, x.Column)
        };
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction {North, East, South, West}
