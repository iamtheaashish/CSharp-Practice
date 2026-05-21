Game game = new();
game.Run();

// end of main method.
public class Game
{
    public Map Map { get; } = new();
    public Player Player { get; } = new();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}).");

            MoveAround(Player);
        }
    }

    public void MoveAround(Player player)
    {
        Console.Write("What do you want to do? ");
        
        string? input = Console.ReadLine()?.ToLower();
        
        switch (input)
        {
            case "move north":
                if (player.Location.Row > 0) player.Location.Row--;
                break;
            case "move south":
                if (player.Location.Row < 3) player.Location.Row++;
                break;
            case "move west":
                if (player.Location.Column > 0) player.Location.Column--;
                break;
            case "move east":
                if (player.Location.Column < 3) player.Location.Column++;
                break;
            default: 
                Console.WriteLine("I don't understand, try again.");
                break;
        }
        
    }

}

public class Map
{
    private Room[,] _rooms;


    public Map()
    {
        _rooms = new Room[4,4];

        for(int row = 0; row < 4; row++)
            for(int column = 0; column < 4; column++)
                _rooms[row,column] = Room.Empty;

        _rooms[0,0] = Room.Enterance;
        _rooms[0,2] = Room.Fountain;
    }
}

public enum Room { Empty, Enterance, Fountain }

public class Player
{
    public Location Location { get; set; } = new(0,0);
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