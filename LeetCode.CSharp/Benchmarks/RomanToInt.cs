namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public int RomanToInt()
    {
        return Problem.RomanToInt("MMMCMXCIXCMXCIX");
    }
}