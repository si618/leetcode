namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsAnagram))]
    public void IsAnagramSetup()
    {
        var range = Enumerable.Range(1, 1_000).ToArray();
        _string1 = string.Join("", range.Select(i => i.ToString()));
        _string2 = string.Join("", range.Reverse().Select(i => i.ToString()));
    }

    [Benchmark]
    public bool IsAnagram()
    {
        return Problem.IsAnagram(_string1, _string2);
    }
}