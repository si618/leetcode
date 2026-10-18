namespace LeetCode.CSharp;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class LeetCodeAttribute(
    string description,
    Difficulty difficulty,
    Category category,
    string uri = "") : Attribute
{
    /// <summary>Challenge description</summary>
    public string Description { get; } = description;

    /// <summary>LeetCode difficulty</summary>
    public Difficulty Difficulty { get; } = difficulty;

    /// <summary>NeetCode category</summary>
    public Category Category { get; } = category;

    /// <summary>Link to NeetCode video</summary>
    public Uri? Link { get; } = string.IsNullOrEmpty(uri) ? null : new Uri($"{uri}", UriKind.Absolute);
}
