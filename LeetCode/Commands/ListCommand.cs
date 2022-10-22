namespace LeetCode.Commands;

internal sealed class ListCommand : Command
{
    public override int Execute([NotNull] CommandContext context)
    {
        ConsoleWriter.WriteHeader(appendLine: false);

        WriteProblemList();

        return 0;
    }

    private static void WriteProblemList()
    {
        var table = new Table();

        table.AddColumn("Problem", config => config.NoWrap = true);
        table.AddColumn("Category");
        table.AddColumn("Difficulty");
        table.AddColumn("Language");
        table.SimpleBorder();
        table.BorderColor(Color.Grey);

        var cSharpBenchmarks = Reflection.GetCSharpBenchmarks().ToArray();
        var fSharpBenchmarks = Reflection.GetFSharpBenchmarks().ToArray();
        var categories = Reflection.GetProblemsByCategory();

        foreach (var category in categories)
        {
            foreach (var problem in category.ToArray())
            {
                var missing = cSharpBenchmarks.Contains(problem.Name)
                    ? string.Empty
                    : " [red]* Missing C# Benchmark *[/]";
                if (problem.FSharp && !fSharpBenchmarks.Contains(problem.Name))
                {
                    missing = string.IsNullOrEmpty(missing)
                        ? " [red]* Missing F# Benchmark *[/]"
                        : " [red]* Missing C# and F# Benchmarks *[/]";
                }

                table.AddRow(
                    problem.Description + missing,
                    problem.Category.Description(),
                    problem.Difficulty.ToMarkup(),
                    problem.LanguageMarkup());
            }
        }

        AnsiConsole.Write(table);
    }
}
