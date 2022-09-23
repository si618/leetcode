namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsAnagram))]
    public void IsAnagramSetup()
    {
        var range = Enumerable.Range(1, 1_000).ToArray();
        String1 = string.Join("", range.Select(i => i.ToString()));
        String2 = string.Join("", range.Reverse().Select(i => i.ToString()));
    }

    [Benchmark]
    public bool IsAnagram()
    {
        return Problem.IsAnagram(String1, String2);
    }
}