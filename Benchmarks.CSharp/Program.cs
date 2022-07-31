using BenchmarkDotNet.Running;
using LeetCode;
using System.Reflection;

var benchmarks = typeof(CSharpBenchmarks)
    .GetMethods()
    .Select(m => m.Name)
    .ToArray();

var challengesInCSharp = typeof(Challenge)
    .GetMembers()
    .Where(m => m.GetCustomAttribute(typeof(LeetCodeAttribute)) is not null)
    .Select(m =>
    {
        var leetCode = m.GetCustomAttribute(typeof(LeetCodeAttribute)) as LeetCodeAttribute;
        return new
        {
            m.Name,
            leetCode!.Description,
            leetCode.Category,
            leetCode.Difficulty
        };
    })
    .OrderBy(s => s.Category)
    .ThenBy(s => s.Difficulty)
    .ThenBy(s => s.Description)
    .GroupBy(s => s.Category, s => s)
    .ToArray();

var total = 0;
var nl = Environment.NewLine;
Console.WriteLine("LeetCode C# Challenges");
foreach (var category in challengesInCSharp)
{
    Console.WriteLine($"{nl}{category.Key.Description()}{nl}");
    foreach (var challenge in category.ToArray())
    {
        var missing = benchmarks.Contains(challenge.Name)
            ? string.Empty
            : " * Missing benchmark *";
        Console.WriteLine($"  [{challenge.Difficulty}] {challenge.Description}{missing}");
    }
    total += category.Count();
}
Console.WriteLine($"{nl}Total challenges: {total}{nl}");

if (!args.Contains("--info", StringComparer.InvariantCultureIgnoreCase))
{
    BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
}
