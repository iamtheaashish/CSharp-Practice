BlockCoordinate blockCoordinate = new BlockCoordinate(4, 3);
BlockOffset blockOffset = new BlockOffset(2, 0);
Direction direction = Direction.East;

BlockCoordinate newCoordinate = blockCoordinate + blockOffset;
Console.WriteLine($"{newCoordinate.Row}, {newCoordinate.Column}");

BlockCoordinate newnewCoordinate = blockCoordinate + direction;
Console.WriteLine($"{newnewCoordinate.Row}, {newnewCoordinate.Column}");

Console.WriteLine($"{newnewCoordinate[0]}, {newnewCoordinate[1]}");

public class BlockCoordinate
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public BlockCoordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

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
            _ => new BlockCoordinate(x.Row, x.Column)
        };
    }

    public int this[int index]
    {
        get => index switch
        {
            0 => Row,
            1 => Column,
            _ => throw new IndexOutOfRangeException()
        };
    }

}
public record BlockOffset(int RowOffset, int ColumnOffset)
{

    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.East  => new BlockOffset(0, 1),
            Direction.South => new BlockOffset(1, 0),
            Direction.West  => new BlockOffset(0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };
    }
}
public enum Direction { North, East, South, West }
