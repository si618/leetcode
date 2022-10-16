namespace LeetCode.ConsoleApp.Menus.Selections;

internal sealed record AboutSelection : Selection
{
    internal AboutSelection(int order) : base("About", order)
    {
    }

    public override int Execute()
    {
        AnsiConsole.Cursor.Hide();

        AnsiConsole.WriteLine("About stuff goes here");

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[gray](Press any key to return to main menu)[/]");
        Console.ReadKey();

        return 0;
    }
}