Console.Clear();
Console.ForegroundColor = ConsoleColor.White;

Robot megatron = new Robot();

while (true)
{
    string? input = Console.ReadLine();
    RobotCommand newCommand;

    switch (input)
    {
        case "on":
            newCommand = new OnCommand();
            break;

        case "off":
            newCommand = new OffCommand();
            break;

        case "north":
            newCommand = new NorthCommand();
            break;

        case "south":
            newCommand = new SouthCommand();
            break;

        case "east":
            newCommand = new EastCommand();
            break;

        case "west":
            newCommand = new WestCommand();
            break;
        
        case "stop":
            Console.WriteLine();
            megatron.Run();


        default:
            Console.WriteLine("Invalid command");
    }

    megatron.Commands.Add = newCommand;
}


// ==> end of main method.

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<RobotCommand> Commands { get; } = new List<RobotCommand>();
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}
public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y += 1;
        }
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }

    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}