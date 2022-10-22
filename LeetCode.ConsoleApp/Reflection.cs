namespace LeetCode.ConsoleApp;

internal static class Reflection
{
    public static bool TryGetProblem(string name, out Problem problem)
    {
        var found = typeof(CSharp.Problems.Problem)
             .GetMembers()
             .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
             .Select(GetProblem)
             .FirstOrDefault(p =>
                 p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                 p.Description.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        problem = found ?? null!;
        return found is not null;
    }

    public static IEnumerable<IGrouping<Category, Problem>> GetProblemsByCategory() =>
        typeof(CSharp.Problems.Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(GetProblem)
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
        typeof(Benchmark).Assembly.GetTypes()
            .Where(type => type.Namespace is not null && !type.IsAbstract &&
                 type.Namespace.StartsWith("LeetCode.CSharp.Benchmarks"));

    public static IEnumerable<Type> GetFSharpBenchmarkTypes() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                type.Namespace.StartsWith("LeetCode.FSharp.Benchmarks"));

    private static IEnumerable<string> GetCSharpProblems() =>
        typeof(CSharp.Problems.Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(m => m.Name);

    private static IEnumerable<string> GetFSharpProblems() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                           type.Namespace.StartsWith("LeetCode.FSharp.Problems"))
            .Select(type => type.Name);

    private static Problem GetProblem(MemberInfo memberInfo)
    {
        ArgumentNullException.ThrowIfNull(nameof(memberInfo));

        var csharp = GetCSharpProblems().Contains(memberInfo.Name);
        var fsharp = GetFSharpProblems().Contains(memberInfo.Name);
        var attribute = memberInfo.GetCustomAttribute<LeetCodeAttribute>();

        if (!csharp && !fsharp || attribute is null)
        {
            throw new ArgumentException("Member info is not a problem", nameof(memberInfo));
        }

        return new Problem(
            memberInfo.Name,
            attribute!.Description,
            attribute.Category,
            attribute.Difficulty,
            attribute.Link,
            csharp,
            fsharp);
    }
}
