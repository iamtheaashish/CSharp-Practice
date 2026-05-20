new FountainOfObjectGame().Run();

// ---> end of main method

public class FountainOfObjectGame
{
    public Player Player { get; }
    public Map Map { get; }

    public FountainOfObjectGame()
    {
        Player = new Player();
        Map = MakeMap();
    }

    public Map MakeMap()
    {
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What game do you want to play? \"small\", \"medium\" or \"large\"");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            Map? map = input switch
            {
                "small" => new Map(4, 4),
                "medium" => new Map(6, 6),
                "large" => new Map(8, 8),
                _ => null
            };

            if (map != null) return map;

            Console.WriteLine("I do not understand that.");
        } while (true);
    }
    public void Run()
    {
        PlayerInput playerInput = new PlayerInput();
        while (!HasWon())
        {
            SenseStuff();
            IAction action = playerInput.ChooseAction();
            action.Execute(this);
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life! You win!");

    }

    private bool HasWon()
    {
        Room playersRoom = Map.GetRoom(Player.Location);
        if (!(playersRoom is EntranceRoom)) return false;

        for (int row = 0; row < Map.Rows; row++)
            for (int column = 0; column < Map.Columns; column++)
            {
                if (Map.GetRoom(row, column) is FountainRoom fountainRoom)
                    if (fountainRoom.IsOff) return false;
            }

        return true;
    }

    public interface IAction
    {
        void Execute(FountainOfObjectGame game);
    }
    public enum Direction { North, South, East, West }
    public class MoveAction : IAction
    {
        private readonly Direction _direction;
        public MoveAction(Direction direction)
        {
            _direction = direction;
        }
        public void Execute(FountainOfObjectGame game)
        {
            Location current = game.Player.Location;
            Location next = GetRelativeLocation(current, _direction);
            if (game.Map.IsOnMap(next))
                game.Player.Location = next;
            else
                Console.WriteLine("You can't move there!");
        }

        private Location GetRelativeLocation(Location start, Direction directionToMove)
        {
            return directionToMove switch
            {
                Direction.North => new Location(start.Row - 1, start.Column),
                Direction.South => new Location(start.Row + 1, start.Column),
                Direction.East => new Location(start.Row, start.Column + 1),
                Direction.West => new Location(start.Row, start.Column - 1),
            };
        }
    }

    public class EnableFountainAction : IAction
    {
        public void Execute(FountainOfObjectGame game)
        {
            Location playersLocation = game.Player.Location;
            Room playersRoom = game.Map.GetRoom(playersLocation);
            FountainRoom? fountainRoom = playersRoom as FountainRoom;
            if (fountainRoom == null)
            {
                Console.WriteLine("You can't do that in this room.");
                return;
            }
            fountainRoom.IsOn = true;
        }
    }
    public class PlayerInput
    {
        public IAction ChooseAction()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? input = Console.ReadLine();
                IAction? chosenAction = input switch
                {
                    "move north" => new MoveAction(Direction.North),
                    "move south" => new MoveAction(Direction.South),
                    "move east" => new MoveAction(Direction.East),
                    "move west" => new MoveAction(Direction.West),
                    "enable fountain" => new EnableFountainAction(),
                    _ => null
                };

                if (chosenAction != null) return chosenAction;
                Console.WriteLine("I do not understand that.");
            } while (true);
        }
    }

    private void SenseStuff()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column})");

        SenseEntranceRoomLight();
        SenseFountainSounds();
    }

    private void SenseEntranceRoomLight()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (Map.GetRoom(Player.Location) is EntranceRoom)
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
    }
    private void SenseFountainSounds()
    {
        if (Map.GetRoom(Player.Location) is FountainRoom fountainRoom)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (fountainRoom.IsOn) Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            else Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        }
    }
}

public class Player
{
    public Location Location { get; set; } = new Location(0, 0);
}

public record Location(int Row, int Column);

public class Map
{
    private Room[,] _rooms;

    public Map(int Rows, int Columns)
    {
        _rooms = new Room[Rows, Columns];
        for (int row = 0; row < Rows; row++)
            for (int column = 0; column < Columns; column++)
                _rooms[row, column] = new EmptyRoom();

        _rooms[0, 0] = new EntranceRoom();
        _rooms[0, 2] = new FountainRoom();
    }

    // public int Rows => 4;
    // public int Columns => 4;

    public bool IsOnMap(Location location)
    {
        if (location.Row < 0) return false;
        if (location.Row >= Rows) return false;
        if (location.Column < 0) return false;
        if (location.Column >= Columns) return false;
        return true;
    }

    public Room GetRoom(int row, int column) => _rooms[row, column];
    public Room GetRoom(Location location) => _rooms[location.Row, location.Column];

}
public abstract class Room { }
public class EmptyRoom : Room { }
public class EntranceRoom : Room { }
public class FountainRoom : Room
{
    public bool IsOn { get; set; }
    public bool IsOff => !IsOn;
}