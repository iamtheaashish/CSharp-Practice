new GameLoop().Run();

// ---> end of main method
public class GameLoop
{
    public Grid Grid {get;} = new Grid();
    public Player Player {get;} = new Player();

    public void Run()
    {
        while(true)
        {
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row={Player.CurrentLocation.row}, Column={Player.CurrentLocation.column}).");
        break;
        }
    }
}

public class PlayerInput
{
    
}

public class Player
{
    public Location CurrentLocation { get; set; } = new Location(0, 0);
    
}
public record Location (int row, int column);

public class Grid
{
   public Room[,] _rooms;

    public Grid()
    {
        _rooms = new Room[4,4];
        for(int row = 0; row < 4; row++)
            for(int column = 0; column < 4; column++)
            {
                _rooms[row, column] = new EmptyRoom();
            }

        
        _rooms[0, 0] = new EntranceRoom();
        _rooms[0, 2] = new FountainRoom();
    }
}

public abstract class Room { }
public class EmptyRoom : Room { }
public class EntranceRoom : Room { }
public class FountainRoom : Room
{
    public bool IsFlowing { get; set; }
}
