namespace LeetCode.ConsoleApp;

internal static class Reflection
{
    public static ProblemDetail? GetProblem(string name) =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(GetProblemDetail)
            .FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                p.Description.Equals(name, StringComparison.InvariantCultureIgnoreCase));

    public static IEnumerable<IGrouping<Category, ProblemDetail>> GetProblemsByCategory() =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(GetProblemDetail)
            .OrderBy(s => s.Category)
            .ThenBy(s => s.Difficulty)
            .ThenBy(s => s.Description)
            .GroupBy(s => s.Category, s => s);

    public static IEnumerable<string> GetCSharpBenchmarks() =>
        typeof(CSharp.Benchmarks.Benchmark).GetMethods().Select(m => m.Name);

    public static IEnumerable<string> GetFSharpBenchmarks() =>
        GetFSharpBenchmarkTypes().Select(m => m.Name);

    public static IEnumerable<Type> GetFSharpBenchmarkTypes() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(t => t.Namespace is not null &&
                t.Namespace.StartsWith("LeetCode.FSharp.Benchmarks"));

    private static ProblemDetail GetProblemDetail(MemberInfo memberInfo)
    {
        ArgumentNullException.ThrowIfNull(nameof(memberInfo));

        // All problems have a C# implementation and some may also be solved in F#
        var fSharpType = $"LeetCode.FSharp.Problems.{memberInfo.Name}, LeetCode.FSharp";
        var language = Type.GetType(fSharpType) is null
            ? "C#"
            : "C# F#";

        var attribute = memberInfo.GetCustomAttribute<LeetCodeAttribute>();

        return new ProblemDetail(
            memberInfo.Name,
            attribute!.Description,
            attribute.Category,
            attribute.Difficulty,
            language,
            attribute.Link);
    }
}
