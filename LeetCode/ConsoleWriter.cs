namespace LeetCode;

internal static class ConsoleWriter
{
    private static readonly Rainbow Lolcat = new(new RainbowStyle(EscapeSequence.Spectre));
    private static readonly AnimationStyle AnimationStyle = new(
        Duration: TimeSpan.FromSeconds(1.42),
        PadToWindowSize: false,
        StopOnResize: true);

    public static void WriteHeader(bool clearConsole = false)
    {
        if (clearConsole)
        {
            AnsiConsole.Clear();
        }

        Lolcat.WriteLineWithMarkup(Resources.LeetCode_Figlet);
    }

    public static void AnimateHeader()
    {
        AnsiConsole.Clear();

        Lolcat.Animate(Resources.LeetCode_Figlet, AnimationStyle);

        AnsiConsole.WriteLine();
    }

    public static void WaitForKeyPress()
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(Resources.Console_ReturnToMainMenu_Markup);

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();
    }
}
