namespace LeetCode;

internal static class ConsoleWriter
{
    private static readonly Rainbow Lolcat = new(new RainbowStyle(EscapeSequence.Spectre));

    public static void WriteHeader(bool clearConsole = false)
    {
        if (clearConsole)
        {
            AnsiConsole.Clear();
        }

        var output = Lolcat.Markup(Resources.LeetCode_Figlet);

        AnsiConsole.Markup(output);
    }

    public static void WaitForKeyPress()
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(Resources.Console_ReturnToMainMenu_Markup);

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();
    }
}
