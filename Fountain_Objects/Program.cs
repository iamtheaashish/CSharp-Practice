Game game = new();
game.Run();

// end of main method.
public class Game
{
    public Map Map { get; } = new(4, 4);
    public Player Player { get; } = new();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}).");
            ToDo();
        }
    }

    public void ToDo()
    {
        Console.Write("What do you want to do? ");

        string? input = Console.ReadLine()?.ToLower();

        switch (input)
        {
            case "move north":
                if (Player.Location.Row > 0) Player.Location.Row--;
                break;

            case "move south":
                if (Player.Location.Row < Map.Rows - 1) Player.Location.Row++;
                break;

            case "move west":
                if (Player.Location.Column > 0) Player.Location.Column--;
                break;

            case "move east":
                if (Player.Location.Column < Map.Columns - 1) Player.Location.Column++;
                break;
        }

    }

}

public class Map
{
    private Room[,] _rooms;
    public int Rows { get; }
    public int Columns { get; }

    public Map(int row, int column)
    {
        Rows = row;
        Columns = column;

        _rooms = new Room[Rows,Columns];

        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                _rooms[i, j] = Room.Empty;

        _rooms[0, 0] = Room.Entrance;
        _rooms[0, 2] = Room.Fountain;
    }
}

public enum Room { Empty, Entrance, Fountain }

public class Player
{
    public Location Location { get; set; } = new(0, 0);
}

public class Location
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Location(int row, int column)
    {
        Row = row;
        Column = column;
    }
}