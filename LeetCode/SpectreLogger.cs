namespace LeetCode;

internal sealed class SpectreLogger : ILogger
{
    public static readonly SpectreLogger Logger = new();

    public void Write(LogKind logKind, string text)
    {
        Markup(logKind, text, writeLine: false);
    }

    public void WriteLine()
    {
        AnsiConsole.WriteLine();
    }

    public void WriteLine(LogKind logKind, string text)
    {
        Markup(logKind, text, writeLine: true);
    }

    public void Flush()
    {
    }

    public string Id { get; } = nameof(SpectreLogger);

    public int Priority { get; } = 0;

    private static void Markup(LogKind logKind, string text, bool writeLine)
    {
        var prefix = string.Empty;
        switch (logKind)
        {
            case LogKind.Default:
            case LogKind.Help:
            case LogKind.Header:
            case LogKind.Result:
            case LogKind.Statistic:
            case LogKind.Info:
            case LogKind.Hint:
                break;
            case LogKind.Error:
                prefix = "[red]Error[/]: ";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logKind), logKind, null);
        }

        if (writeLine)
        {
            AnsiConsole.MarkupLineInterpolated($"{prefix}{text}");
        }
        else
        {
            AnsiConsole.MarkupInterpolated($"{prefix}{text}");
        }
    }
}
