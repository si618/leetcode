namespace LeetCode.Menus.Selections;

internal sealed record AboutSelection : Selection
{
    internal AboutSelection(int order) : base("About", order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true, appendLine: true);

        AnsiConsole.WriteLine("About stuff goes here");

        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[gray](Press any key to return to main menu)[/]");

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();

        return 0;
    }
}