namespace LeetCode.Commands;

internal sealed class AppCommand : Command
{
    public override int Execute(CommandContext context)
    {
        try
        {
            new MainMenu().Render();

            return 0;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -99;
        }
    }
}
