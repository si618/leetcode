﻿namespace LeetCode;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class LeetCodeAttribute : Attribute
{
    /// <summary>Challenge description</summary>
    public string Description { get; }

    /// <summary>LeetCode difficulty</summary>
    public Difficulty Difficulty { get; }

    /// <summary>NeetCode category</summary>
    public Category Category { get; }

    /// <summary>Link to NeetCode video</summary>
    public Uri? Link { get; }

    public LeetCodeAttribute(string description, Difficulty difficulty, Category category, string yt = "")
    {
        Description = description;
        Difficulty = difficulty;
        Category = category;
        Link = string.IsNullOrEmpty(yt)
            ? null
            : new Uri($"https://www.youtube.com/watch?v={yt}", UriKind.Absolute);
    }
}
