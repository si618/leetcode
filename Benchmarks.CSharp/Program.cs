using BenchmarkDotNet.Running;
using LeetCode;
using System.Reflection;

var benchmarks = typeof(Benchmark).GetMethods().Select(m => m.Name);
var submissionsInCSharp = typeof(Submission)
    .GetMethods()
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
    .GroupBy(s => s.Category, s => s);

Console.WriteLine("LeetCode Challenges");
foreach (var category in submissionsInCSharp)
{
    Console.WriteLine(category.Key.Description());
    foreach (var submission in category)
    {
        var missing = benchmarks.Contains(submission.Name)
            ? string.Empty
            : " * Missing benchmark *";
        Console.WriteLine($"  [{submission.Difficulty}] {submission.Description}{missing}");
    }
}

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);