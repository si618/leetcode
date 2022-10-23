namespace LeetCode.Menus.Selections;

internal sealed record BenchmarkLogSelection : Selection
{
    internal BenchmarkLogSelection(int order) : base("Benchmark logs", order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true, appendLine: true);

        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[gray](Press any key to return to main menu)[/]");

        AnsiConsole.Cursor.Hide();

        Console.ReadKey();

        return 0;
    }
}