using BenchmarkDotNet.Running;
using LeetCode;
using System.Reflection;

var benchmarks = typeof(CSharpBenchmarks)
    .GetMethods()
    .Select(m => m.Name)
    .ToArray();

var problems = typeof(Problem)
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

const string asciiArt =
@"    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/
";
Console.WriteLine(asciiArt);
Console.WriteLine("C# Problems");

var total = 0;
var nl = Environment.NewLine;
foreach (var category in problems)
{
    Console.WriteLine($"{nl}{category.Key.Description()}{nl}");
    foreach (var problem in category.ToArray())
    {
        var missing = benchmarks.Contains(problem.Name)
            ? string.Empty
            : " * Missing Benchmark *";
        Console.WriteLine($"  [{problem.Difficulty}] {problem.Description}{missing}");
    }
    total += category.Count();
}
Console.WriteLine($"{nl}Total Problems: {total}{nl}");

if (!args.Contains("--info", StringComparer.InvariantCultureIgnoreCase))
{
    BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
}
