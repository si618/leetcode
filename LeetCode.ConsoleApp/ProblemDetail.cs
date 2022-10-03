namespace LeetCode.ConsoleApp;

public record ProblemDetail(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    string Language,
    Uri? Link) : IComparable<ProblemDetail>
{
    public int CompareTo(ProblemDetail? other) => Name.Equals(other?.Name) ? 0 : 1;
}
