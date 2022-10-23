namespace LeetCode;

internal static class ConsoleWriter
{
    private static readonly RainbowWriter RainbowWriter = new(useSpectreMarkup: true);

    public static void WriteHeader(bool clearConsole = false, bool appendLine = false)
    {
        if (clearConsole)
        {
            AnsiConsole.Clear();
        }

        var output = RainbowWriter.Write(Resources.LeetCode_Figlet);

        AnsiConsole.Markup(output);

        if (appendLine)
        {
            AnsiConsole.WriteLine();
        }
    }

    public static void WaitForKeyPress()
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(Resources.Console_ReturnToMainMenu_Markup);

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();
    }
}
