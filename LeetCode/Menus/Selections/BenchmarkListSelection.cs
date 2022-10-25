namespace LeetCode.Menus.Selections;

internal sealed record BenchmarkListSelection : Selection
{
    internal BenchmarkListSelection(int order) : base("Run Benchmarks", order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        AnsiConsole.WriteLine("TODO: Multi selection prompt to run all or selected benchmarks in C# or F#");

        ConsoleWriter.WaitForKeyPress();

        return 0;
    }
}