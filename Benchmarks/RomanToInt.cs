namespace LeetCode;
using BenchmarkDotNet.Attributes;

public partial class Benchmarks
{
    [Benchmark]
    public void RomanToInt()
    {
        Submission.RomanToInt("III");
        Submission.RomanToInt("LVIII");
        Submission.RomanToInt("MCMXCIV");
    }
}