namespace LeetCode.CSharp.Benchmarks;

public class RomanToIntBenchmark : Benchmark
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public int RomanToInt()
    {
        return Problem.RomanToInt("MMMCMXCIXCMXCIX");
    }
}