namespace Benchmarks.CSharp;

internal static class ConsoleWriter
{
    public static void WriteHeader()
    {
        Console.WriteLine(
@"    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/
");
    }

    public static void WriteProblems()
    {
        Console.WriteLine("Solved C# Problems");

        var countOfProblems = 0;
        var nl = Environment.NewLine;
        var benchmarks = Reflection.GetCSharpBenchmarks().ToArray();

        foreach (var category in Reflection.GetProblemsByCategory())
        {
            Console.WriteLine($"{nl}{category.Key.Description()}{nl}");

            foreach (var problem in category.ToArray())
            {
                var missing = benchmarks.Contains(problem.Name)
                    ? string.Empty
                    : " * Missing Benchmark *";
                Console.WriteLine($"  [{problem.Difficulty}] {problem.Description}{missing}");
            }

            countOfProblems += category.Count();
        }

        Console.WriteLine($"{nl}Total Problems: {countOfProblems}{nl}");
    }
}
