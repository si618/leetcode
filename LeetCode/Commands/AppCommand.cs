namespace LeetCode.Commands;

internal sealed class AppCommand : Command
{
    protected override int Execute(CommandContext context, CancellationToken cancellationToken)
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
