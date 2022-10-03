namespace LeetCode.ConsoleApp.Menus;

internal sealed class ProblemList : MenuSelection
{
    public ProblemList(MenuItem menuItem) : base(menuItem)
    {
    }

    public override void Execute()
    {
        var problems = Reflection
            .GetProblemsByCategory()
            .SelectMany(g => g)
            .ToArray();

        var padding = new ProblemDetailPadding(
            problems.Max(problem => problem.Description.Length),
            problems.Max(problem => problem.Category.Description().Length));

        var prompt = new SelectionPrompt<ProblemDetail>()
            .AddChoices(problems)
            .PageSize(16)
            .UseConverter(problem => ConvertProblemDetail(problem, padding))
            .MoreChoicesText("[gray](Move up and down to reveal more problems)[/]");

        var table = new Table
        {
            Border = TableBorder.Simple,
            UseSafeBorder = true
        };
        table.AddColumns("Problem", "Category", "Difficulty");
        table.Columns[0].Width = padding.DescriptionPad;
        table.Columns[1].Width = padding.CategoryPad;
        AnsiConsole.Write(table);

        var problem = AnsiConsole.Prompt(prompt);
        AnsiConsole.Markup($"TODO Show details on problem [green]{problem.Name}[/]");
        Console.ReadLine();
    }

    private sealed record ProblemDetailPadding(int DescriptionPad, int CategoryPad);

    private static string ConvertProblemDetail(ProblemDetail problem, ProblemDetailPadding padding)
        => new StringBuilder()
            .Append($"{problem.Description.PadRight(padding.DescriptionPad + 3)}")
            .Append($"{problem.Category.Description().PadRight(padding.CategoryPad + 3)}")
            .Append($"{problem.Difficulty.ToMarkup()}")
            .ToString();
}