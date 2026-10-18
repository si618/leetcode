namespace LeetCode;

internal static class Reflection
{
    public static bool TryGetProblem(string name, out Problem problem)
    {
        var found = typeof(CSharp.Problems.Problem)
            .GetMembers()
            .Where(m => Attribute.IsDefined(m, typeof(LeetCodeAttribute)))
            .Select(GetProblem)
            .FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Equals(name, StringComparison.OrdinalIgnoreCase));

        problem = found ?? null!;

        return found is not null;
    }

    private static Problem GetProblem(MemberInfo memberInfo)
    {
        var csharp = GetCSharpProblems().Contains(memberInfo.Name, StringComparer.Ordinal);
        var fsharp = GetFSharpProblems().Contains(memberInfo.Name, StringComparer.Ordinal);
        var attribute = memberInfo.GetCustomAttribute<LeetCodeAttribute>();

        return attribute is null || (!csharp && !fsharp)
            ? throw new InvalidOperationException($"Invalid member info '{memberInfo.Name}")
            : new Problem(
            memberInfo.Name,
            attribute.Description,
            attribute.Category,
            attribute.Difficulty,
            attribute.Link,
            csharp,
            fsharp);
    }

    public static IEnumerable<IGrouping<Category, Problem>> GetProblemsByCategory() =>
        typeof(CSharp.Problems.Problem)
            .GetMembers()
            .Where(m => Attribute.IsDefined(m, typeof(LeetCodeAttribute)))
            .Select(GetProblem)
            .OrderBy(p => p.Category)
            .ThenBy(p => p.Difficulty)
            .ThenBy(p => p.Description, StringComparer.Ordinal)
            .GroupBy(p => p.Category, p => p);

    public static IEnumerable<string> GetCSharpBenchmarks() =>
        GetCSharpBenchmarkTypes().Select(type =>
            type.Name.EndsWith("Benchmark", StringComparison.Ordinal) ? type.Name[..^9] : type.Name);

    public static IEnumerable<string> GetFSharpBenchmarks() =>
        GetFSharpBenchmarkTypes().Select(type =>
            type.Name.EndsWith("Benchmark", StringComparison.Ordinal) ? type.Name[..^9] : type.Name);

    public static IEnumerable<Type> GetCSharpBenchmarkTypes() =>
        typeof(Benchmark).Assembly.GetTypes()
            .Where(type => type.Namespace is not null && !type.IsAbstract &&
                 type.Namespace.StartsWith("LeetCode.CSharp.Benchmarks", StringComparison.Ordinal));

    public static IEnumerable<Type> GetFSharpBenchmarkTypes() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                type.Namespace.StartsWith("LeetCode.FSharp.Benchmarks", StringComparison.Ordinal));

    private static IEnumerable<string> GetCSharpProblems() =>
        typeof(CSharp.Problems.Problem)
            .GetMembers()
            .Where(m => Attribute.IsDefined(m, typeof(LeetCodeAttribute)))
            .Select(m => m.Name);

    private static IEnumerable<string> GetFSharpProblems() =>
        typeof(FSharp.ListNode).Assembly.GetTypes()
            .Where(type => type.Namespace is not null &&
                           type.Namespace.StartsWith("LeetCode.FSharp.Problems", StringComparison.Ordinal))
            .Select(m => m.Name);
}
