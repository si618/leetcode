namespace LeetCode.CSharp.Benchmarks;

public class ReverseBitsBenchmark : Benchmark
{
    [Benchmark]
    public uint ReverseBits() => Problem.ReverseBits(0b00100010100101000001111010011100);
}