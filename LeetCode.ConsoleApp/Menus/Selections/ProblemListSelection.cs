﻿namespace LeetCode.ConsoleApp.Menus.Selections;

internal sealed record ProblemListSelection : Selection
{
    internal ProblemListSelection(int order) : base("List Problems", order)
    {
    }

    public override int Execute()
    {
        AnsiConsole.Clear();
        ConsoleWriter.WriteHeader(appendLine: false);

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
            .MoreChoicesText("[gray](Move up and down to reveal more problems or X to exit)[/]");

        var table = new Table
        {
            Border = TableBorder.Simple,
            UseSafeBorder = true
        };
        table.AddColumns("Problem", "Category", "Difficulty");
        table.Columns[0].Width = padding.DescriptionPad;
        table.Columns[1].Width = padding.CategoryPad;
        AnsiConsole.Write(table);

        // TODO Capture X (or whatever) to return to main menu instead of forcing selection
        var problem = AnsiConsole.Prompt(prompt);

        new ProblemMenu(problem).Render();

        return 0;
    }

    private sealed record ProblemDetailPadding(int DescriptionPad, int CategoryPad);

    private static string ConvertProblemDetail(ProblemDetail problem, ProblemDetailPadding padding)
        => new StringBuilder()
            .Append($"{problem.Description.PadRight(padding.DescriptionPad + 3)}")
            .Append($"{problem.Category.Description().PadRight(padding.CategoryPad + 3)}")
            .Append($"{problem.Difficulty.ToMarkup()}")
            .ToString();
}