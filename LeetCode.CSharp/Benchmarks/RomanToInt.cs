namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public int RomanToInt()
    {
        return Problem.RomanToInt("MMMCMXCIXCMXCIX");
    }
}