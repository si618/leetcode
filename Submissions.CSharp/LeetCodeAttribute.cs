namespace LeetCode;

[AttributeUsage(AttributeTargets.Method)]
public sealed class LeetCodeAttribute : Attribute
{
    /// <summary>LeetCode difficulty</summary>
    public Difficulty Difficulty { get; }
    /// <summary>NeetCode category</summary>
    public Category Category { get; }

    public LeetCodeAttribute(Difficulty difficulty, Category category)
    {
        Difficulty = difficulty;
        Category = category;
    }
}

/// <summary>LeetCode difficulty</summary>
public enum Difficulty
{
    /// <summary>Easy</summary>
    Easy,
    /// <summary>Medium</summary>
    Medium,
    /// <summary>Hard</summary>
    Hard
}

/// <summary>NeetCode category</summary>
public enum Category
{
    /// <summary>Not in NeetCode</summary>
    None,
    /// <summary>Advanced Graphs</summary>
    AdvancedGraphs,
    /// <summary>Arrays & Hashing</summary>
    ArraysAndHashing,
    /// <summary>Back Tracking</summary>
    BackTracking,
    /// <summary>Binary Search</summary>
    BinarySearch,
    /// <summary>Bit Manipulation</summary>
    BitManipulation,
    /// <summary>Graphs</summary>
    Graphs,
    /// <summary>Greedy</summary>
    Greedy,
    /// <summary>Heap / PriorityQueue</summary>
    HeapPriorityQueue,
    /// <summary>Intervals</summary>
    Intervals,
    /// <summary>Linked List</summary>
    LinkedList,
    /// <summary>Math and Geometry</summary>
    MathAndGeometry,
    /// <summary>1-D Dynamic Programming</summary>
    OneDDynamicProgramming,
    /// <summary>Sliding Window</summary>
    SlidingWindow,
    /// <summary>Stack</summary>
    Stack,
    /// <summary>Trees</summary>
    Trees,
    /// <summary>Tries</summary>
    Tries,
    /// <summary>2-D Dynamic Programming</summary>
    TwoDDynamicProgramming,
    /// <summary>Two Pointers</summary>
    TwoPointers
}