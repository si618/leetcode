namespace LeetCode;

[SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case",
    Justification = "False positive on the compiler-generated names of C# 14 extension blocks")]
public static partial class Extensions
{
    extension(Category category)
    {
        public string Description() =>
            $"Category_{category}".GetResource();
    }

    extension(Difficulty difficulty)
    {
        public string Markup() =>
            $"Difficulty_{difficulty}_Markup".GetResource();
    }

    extension(Problem problem)
    {
        internal bool HasSimilarNameAndDescription() => string.Equals(problem.Description.ReplaceWhitespace(string.Empty), problem.Name, StringComparison.Ordinal);

        internal Table Markup()
        {
            var table = new Table
            {
                Border = TableBorder.None,
                ShowHeaders = false,
            };

            table.AddColumn(new TableColumn("-").PadRight(3));
            table.AddColumn("-");

            table.AddRow(Resources.Problem_Benchmark_Markup, problem.Name);

            if (!string.Equals(problem.Name, problem.Description, StringComparison.Ordinal))
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
    }

    extension(string input)
    {
        private string ReplaceWhitespace(string replacement) =>
            MatchWhitespace.Replace(input, replacement);

        private string GetResource() =>
            Resources.ResourceManager.GetString(input, CultureInfo.InvariantCulture) ??
            throw new InvalidOperationException($"Missing resource '{input}'");
    }

    [GeneratedRegex(@"\s+", RegexOptions.None, matchTimeoutMilliseconds: 1000)]
    private static partial Regex MatchWhitespace { get; }
}
