namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public int RomanToInt()
    {
        return Problem.RomanToInt("MMMCMXCIXCMXCIX");
    }
}