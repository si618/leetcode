namespace LeetCode;

internal static class ConsoleWriter
{
    private static readonly Rainbow Lolcat = new(new RainbowStyle(EscapeSequence.Spectre));
    private static readonly AnimationStyle AnimationStyle = new(
        Duration: TimeSpan.FromSeconds(1.42),
        PadToWindowSize: false,
        Speed: 42,
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

    /// <summary>
    /// Moves the cursor, unless output is redirected. Spectre.Console then falls back to
    /// Console.SetCursorPosition, which throws when the cursor would leave the buffer.
    /// </summary>
    public static void MoveCursor(CursorDirection direction, int steps = 1)
    {
        if (Console.IsOutputRedirected)
        {
            return;
        }

        AnsiConsole.Cursor.Move(direction, steps);
    }

    public static void WaitForKeyPress()
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(Resources.Console_ReturnToMainMenu_Markup);

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();
    }
}
