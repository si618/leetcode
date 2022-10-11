namespace LeetCode.ConsoleApp.Menus.Selections;

internal record BenchmarkLogSelection : Selection
{
    internal BenchmarkLogSelection(int order) : base("Benchmark logs", order)
    {
    }

    public override int Execute()
    {
        AnsiConsole.Cursor.Hide();

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[gray](Press any key to return to main menu)[/]");
        Console.ReadKey();

        return 0;
    }
}