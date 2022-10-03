namespace LeetCode.ConsoleApp.Commands;

using System.Diagnostics.CodeAnalysis;

internal sealed class ProblemListCommand : Command
{
    public override int Execute([NotNull] CommandContext context)
    {
        ConsoleWriter.WriteHeader();
        WriteProblemList();
        return 0;
    }

    public static void WriteProblemList()
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

        foreach (var category in Reflection.GetProblemsByCategory())
        {
            foreach (var problem in category.ToArray())
            {
                var missing = cSharpBenchmarks.Contains(problem.Name)
                    ? string.Empty
                    : " [red]* Missing C# Benchmark *[/]";
                if (problem.Language.Contains("F#") && !fSharpBenchmarks.Contains(problem.Name))
                {
                    missing = string.IsNullOrEmpty(missing)
                        ? " [red]* Missing F# Benchmark *[/]"
                        : " [red]* Missing C# and F# Benchmarks *[/]";
                }

                table.AddRow(
                    problem.Description + missing,
                    problem.Category.Description(),
                    problem.Difficulty.ToMarkup(),
                    problem.Language);
            }
        }

        AnsiConsole.Write(table);
    }
}
