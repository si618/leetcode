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
        GetCSharpBenchmarkTypes().Select(type =>
            type.Name.EndsWith("Benchmark") ? type.Name[..^9] : type.Name);

    public static IEnumerable<string> GetFSharpBenchmarks() =>
        GetFSharpBenchmarkTypes().Select(type =>
            type.Name.EndsWith("Benchmark") ? type.Name[..^9] : type.Name);

    public static IEnumerable<Type> GetCSharpBenchmarkTypes() =>
        typeof(CSharp.Benchmark).Assembly.GetTypes()
            .Where(type => type.Namespace is not null && !type.IsAbstract &&
                 type.Namespace.StartsWith("LeetCode.CSharp.Benchmarks"));

    public static IEnumerable<Type> GetFSharpBenchmarkTypes() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                type.Namespace.StartsWith("LeetCode.FSharp.Benchmarks"));

    public static IEnumerable<string> GetCSharpProblems() =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(m => m.Name);

    public static IEnumerable<string> GetFSharpProblems() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                           type.Namespace.StartsWith("LeetCode.FSharp.Problems"))
            .Select(type => type.Name);

    private static ProblemDetail GetProblemDetail(MemberInfo memberInfo)
    {
        ArgumentNullException.ThrowIfNull(nameof(memberInfo));

        var csharp = GetCSharpProblems().Contains(memberInfo.Name);
        var fsharp = GetFSharpProblems().Contains(memberInfo.Name);
        var attribute = memberInfo.GetCustomAttribute<LeetCodeAttribute>();

        return new ProblemDetail(
            memberInfo.Name,
            attribute!.Description,
            attribute.Category,
            attribute.Difficulty,
            attribute.Link,
            csharp,
            fsharp);
    }
}
