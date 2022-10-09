namespace LeetCode.ConsoleApp.Commands;

public sealed class ConsoleAppCommand : Command
{
    public override int Execute(CommandContext context)
    {
        new MainMenu().Render();

        return 0;
    }
}
