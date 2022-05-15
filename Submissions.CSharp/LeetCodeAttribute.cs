// ReSharper disable once CheckNamespace
namespace LeetCode;

[AttributeUsage(AttributeTargets.Method)]
public sealed class LeetCodeAttribute : Attribute
{
    /// <summary>Challenge description</summary>
    public string Description { get; }
    /// <summary>LeetCode difficulty</summary>
    public Difficulty Difficulty { get; }
    /// <summary>NeetCode category</summary>
    public Category Category { get; }

    public LeetCodeAttribute(string description, Difficulty difficulty, Category category)
    {
        Description = description;
        Difficulty = difficulty;
        Category = category;
    }
}
