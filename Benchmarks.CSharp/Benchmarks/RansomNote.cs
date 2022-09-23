namespace LeetCode;

using System.Text;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(RansomNote))]
    public void RansomNoteSetup()
    {
        String1 = BuildPseudoRandomString(100);
        String2 = BuildPseudoRandomString(1_000_000);
    }

    [Benchmark]
    public bool RansomNote()
    {
        return Problem.RansomNote(String1, String2);
    }

    [GlobalCleanup(Target = nameof(RansomNote))]
    public void RansomNoteCleanup()
    {
        String1 = string.Empty;
        String2 = string.Empty;
    }
}