namespace LeetCode.CSharp.Benchmarks;

public class NumIslandsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(NumIslands))]
    public void NumIslandsSetup()
    {
        var random = new Random(618);

        CharArrayMulti = new char[1_000][];
        for (var i = 0; i < CharArrayMulti.Length; i++)
        {
            CharArrayMulti[i] = new char[1_000];
            for (var j = 0; j < CharArrayMulti[i].Length; j++)
            {
                var isLand = j % random.Next(1, 10) == 0;
                CharArrayMulti[i][j] = isLand ? '1' : '0';
            }
        }
    }

    [Benchmark]
    public int NumIslands() => Problem.NumIslands(CharArrayMulti);

    [GlobalCleanup(Target = nameof(NumIslands))]
    public void NumIslandsCleanup()
    {
        CharArrayMulti = new[] { new[] { char.MinValue } };
    }
}
