namespace LeetCode.ConsoleApp.Commands;

public sealed class AppCommand : Command
{
    public override int Execute(CommandContext context)
    {
        new MainMenu().Render();

        return 0;
    }
}
