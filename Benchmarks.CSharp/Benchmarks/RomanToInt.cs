namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void RomanToInt()
    {
        // ReSharper disable StringLiteralTypo
        Problem.RomanToInt("III");
        Problem.RomanToInt("LVIII");
        Problem.RomanToInt("MCMXCIV");
    }
}