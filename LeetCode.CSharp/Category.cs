namespace LeetCode;

/// <summary>NeetCode category</summary>
public enum Category
{
    /// <summary>Not in NeetCode</summary>
    NotInNeetCode = 0,
    /// <summary>Arrays & Hashing</summary>
    ArraysAndHashing = 1,
    /// <summary>Two Pointers</summary>
    TwoPointers = 2,
    /// <summary>Sliding Window</summary>
    SlidingWindow = 3,
    /// <summary>Stack</summary>
    Stack = 4,
    /// <summary>Binary Search</summary>
    BinarySearch = 5,
    /// <summary>Linked List</summary>
    LinkedList = 6,
    /// <summary>Trees</summary>
    Trees = 7,
    /// <summary>Tries</summary>
    Tries = 8,
    /// <summary>Heap / Priority Queue</summary>
    HeapPriorityQueue = 9,
    /// <summary>Back Tracking</summary>
    BackTracking = 10,
    /// <summary>Graphs</summary>
    Graphs = 11,
    /// <summary>Advanced Graphs</summary>
    AdvancedGraphs = 12,
    /// <summary>1-D Dynamic Programming</summary>
    OneDDynamicProgramming = 13,
    /// <summary>2-D Dynamic Programming</summary>
    TwoDDynamicProgramming = 14,
    /// <summary>Greedy</summary>
    Greedy = 15,
    /// <summary>Intervals</summary>
    Intervals = 16,
    /// <summary>Math and Geometry</summary>
    MathAndGeometry = 17,
    /// <summary>Bit Manipulation</summary>
    BitManipulation = 18
}

public static class CategoryExtensions
{
    public static string Description(this Category category) => category switch
    {
        Category.NotInNeetCode => "Not listed in NeetCode",
        Category.ArraysAndHashing => "Arrays & Hashing",
        Category.TwoPointers => "Two Pointers",
        Category.SlidingWindow => "Sliding Window",
        Category.Stack => "Stack",
        Category.BinarySearch => "Binary Search",
        Category.LinkedList => "Linked List",
        Category.Trees => "Trees",
        Category.Tries => "Tries",
        Category.HeapPriorityQueue => "Heap / Priority Queue",
        Category.BackTracking => "Back Tracking",
        Category.Graphs => "Graphs",
        Category.AdvancedGraphs => "Advanced Graphs",
        Category.OneDDynamicProgramming => "1-D Dynamic Programming",
        Category.TwoDDynamicProgramming => "2-D Dynamic Programming",
        Category.Greedy => "Greedy",
        Category.Intervals => "Intervals",
        Category.MathAndGeometry => "Maths & Geometry",
        Category.BitManipulation => "Bit Manipulation",
        _ => throw new InvalidOperationException($"Missing description for {category}")
    };
}