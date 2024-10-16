﻿namespace LeetCode;

public static partial class Extensions
{
    public static string Description(this Category category) =>
        $"Category_{category}".GetResource();

    public static string Markup(this Difficulty difficulty) =>
        $"Difficulty_{difficulty}_Markup".GetResource();

    internal static bool HasSimilarNameAndDescription(this Problem problem) =>
        problem.Description.ReplaceWhitespace(string.Empty) == problem.Name;

    internal static Table Markup(this Problem problem)
    {
        var table = new Table
        {
            Border = TableBorder.None,
            ShowHeaders = false
        };

        table.AddColumn(new TableColumn("-").PadRight(3));
        table.AddColumn("-");

        table.AddRow(Resources.Problem_Benchmark_Markup, problem.Name);

        if (problem.Name != problem.Description)
        {
            table.AddRow(Resources.Problem_Description_Markup, problem.Description);
        }

        table.AddRow(Resources.Problem_Category_Markup, problem.Category.Description());
        table.AddRow(Resources.Problem_Difficulty_Markup, problem.Difficulty.Markup());
        table.AddRow(Resources.Problem_Language_Markup, problem.LanguageMarkup());

        if (problem.Link is not null)
        {
            table.AddRow(Resources.Problem_Link_Markup, problem.Link.ToString());
        }

        return table;
    }

    private static readonly Regex MatchWhitespace = MatchWhitespaceRegex();
    private static string ReplaceWhitespace(this string input, string replacement) =>
        MatchWhitespace.Replace(input, replacement);

    private static string GetResource(this string name) =>
        Resources.ResourceManager.GetString(name) ??
            throw new InvalidOperationException($"Missing resource '{name}'");
    [GeneratedRegex(@"\s+")]
    private static partial Regex MatchWhitespaceRegex();
}
