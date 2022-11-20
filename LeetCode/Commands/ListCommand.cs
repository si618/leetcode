namespace LeetCode.Commands;

internal sealed class ListCommand : Command
{
    [SuppressMessage("ReSharper", "RedundantNullableFlowAttribute")]
    public override int Execute([NotNull] CommandContext context)
    {
        try
        {
            ConsoleWriter.WriteHeader();

            Console.CursorTop -= 1;

            WriteProblemList();

            return 0;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -99;
        }
    }

    private static void WriteProblemList()
    {
        var table = new Table();

        table.AddColumn(Resources.Problem_Name, config => config.NoWrap = true);
        table.AddColumn(Resources.Problem_Category);
        table.AddColumn(Resources.Problem_Difficulty);
        table.AddColumn(Resources.Problem_Language);
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
                    : " " + Resources.ListCommand_Missing_CSharpBenchmark_Markup;

                if (problem.FSharp && !fSharpBenchmarks.Contains(problem.Name))
                {
                    missing = string.IsNullOrEmpty(missing)
                        ? " " + Resources.ListCommand_Missing_FSharpBenchmark_Markup
                        : " " + Resources.ListCommand_Missing_BothBenchmarks_Markup;
                }

                table.AddRow(
                    problem.Description + missing,
                    problem.Category.Description(),
                    problem.Difficulty.Markup(),
                    problem.LanguageMarkup());
            }
        }

        AnsiConsole.Write(table);
    }
}
