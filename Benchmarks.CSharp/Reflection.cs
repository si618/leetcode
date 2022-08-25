namespace Benchmarks.CSharp;

using System.Reflection;

internal static class Reflection
{
    public static IEnumerable<IGrouping<Category, ProblemDetail>> GetProblemsByCategory() =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(m =>
            {
                var a = m.GetCustomAttribute(typeof(LeetCodeAttribute)) as LeetCodeAttribute;
                return new ProblemDetail(m.Name, a!.Description, a.Category, a.Difficulty);
            })
            .OrderBy(s => s.Category)
            .ThenBy(s => s.Difficulty)
            .ThenBy(s => s.Description)
            .GroupBy(s => s.Category, s => s);

    public static IEnumerable<string> GetCSharpBenchmarks() =>
        typeof(CSharpBenchmarks)
            .GetMethods()
            .Select(m => m.Name);
}
