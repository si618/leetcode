namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void RomanToInt()
    {
        // ReSharper disable StringLiteralTypo
        Challenge.RomanToInt("III");
        Challenge.RomanToInt("LVIII");
        Challenge.RomanToInt("MCMXCIV");
    }
}