namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    // private char[][] CharArrayMulti { get; set; } = { new[] { char.MinValue }};

    [GlobalSetup(Target = nameof(NumIslands))]
    public void NumIslandsSetup()
    {
        // CharArrayMulti = new char[10_000][];
        // for (var i = 0; i < CharArrayMulti.Length; i++)
        // {
        //     for (var j = 0; j < CharArrayMulti.Length; j++)
        //     {
        //         CharArrayMulti[i][j] = i % 10 == 0 ? '1' : '0';
        //     }
        // }
    }

    [Benchmark]
    public int NumIslands()
    {
        return 0;
        // return Problem.NumIslands(CharArrayMulti);
    }

    [GlobalCleanup(Target = nameof(NumIslands))]
    public void NumIslandsCleanup()
    {
        // CharArrayMulti = new[] { new[] { char.MinValue } };
    }
}
