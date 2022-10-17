namespace LeetCode.CSharp.Benchmarks;

public class IsAnagramBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(IsAnagram))]
    public void IsAnagramSetup()
    {
        String1 = BuildPseudoRandomString(1_000_000);
        String2 = String1.Reverse().ToString()!;
    }

    [Benchmark]
    public bool IsAnagram() => Problem.IsAnagram(String1, String2);

    [GlobalCleanup(Target = nameof(IsAnagram))]
    public void IsAnagramCleanup()
    {
        String1 = string.Empty;
        String2 = string.Empty;
    }
}