namespace LeetCode.ConsoleApp.Menus;

internal record AboutMenuItem : MenuItem
{
    internal AboutMenuItem(int order) : base("About", order)
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