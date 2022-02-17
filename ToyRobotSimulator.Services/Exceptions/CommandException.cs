namespace ToyRobotSimulator.Services.Exceptions;

public class CommandException : Exception
{
    public CommandException(string? message) : base($"Incorrect command entered \"{message}\"") { }
}
