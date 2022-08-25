namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void RomanToInt()
    {
        Problem.RomanToInt("III");
        Problem.RomanToInt("LVIII");
        Problem.RomanToInt("MCMXCIV");
    }
}