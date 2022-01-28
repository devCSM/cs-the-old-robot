using System;

Robot robot = new Robot();

for (int index = 0; index < robot.Commands.Length; index++)
{
    string input = Console.ReadLine();

    robot.Commands[index] = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SoutCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand()
    };
}

Console.WriteLine();

robot.Run();


public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y++; }
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y--; }
    }
}
public class SoutCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.X--; }
    }
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.X++; }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand[] Commands { get; } = new RobotCommand[3];
    public void Run()
    {
        foreach (RobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
