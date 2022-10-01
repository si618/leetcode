namespace LeetCode.ConsoleApp;

internal static class Reflection
{
    public static ProblemDetail? GetProblem(string name) =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(m =>
            {
                var a = m.GetCustomAttribute(typeof(LeetCodeAttribute)) as LeetCodeAttribute;
                return new ProblemDetail(m.Name, a!.Description, a.Category, a.Difficulty, a.Link);
            })
            .FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                p.Description.Equals(name, StringComparison.InvariantCultureIgnoreCase));

    public static IEnumerable<IGrouping<Category, ProblemDetail>> GetProblemsByCategory() =>
        typeof(Problem)
            .GetMembers()
            .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
            .Select(m =>
            {
                var a = m.GetCustomAttribute(typeof(LeetCodeAttribute)) as LeetCodeAttribute;
                return new ProblemDetail(m.Name, a!.Description, a.Category, a.Difficulty, a.Link);
            })
            .OrderBy(s => s.Category)
            .ThenBy(s => s.Difficulty)
            .ThenBy(s => s.Description)
            .GroupBy(s => s.Category, s => s);

    public static IEnumerable<string> GetCSharpBenchmarks() =>
        GetSharpBenchmarks("LeetCode.CSharpBenchmarks");

    public static IEnumerable<string> GetFSharpBenchmarks() =>
        GetSharpBenchmarks("LeetCode.FSharpBenchmarks");

    private static IEnumerable<string> GetSharpBenchmarks(string name) =>
        AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic)
            .SelectMany(a => a.GetTypes())
            .First(t => t.FullName!.Equals(name))
            .GetMethods()
            .Select(m => m.Name);
}
