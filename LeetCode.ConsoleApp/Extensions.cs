namespace LeetCode.ConsoleApp;

public static class Extensions
{
    public static string Description(this Category category) => category switch
    {
        Category.NotInNeetCode => "Not in NeetCode",
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
        _ => throw new ArgumentOutOfRangeException(
            nameof(category),
            category,
            $"Missing description for {category}")
    };

    public static string ToMarkup(this Difficulty difficulty) => difficulty switch
    {
        Difficulty.Easy => "[green]Easy[/]",
        Difficulty.Medium => "[orange1]Medium[/]",
        Difficulty.Hard => "[red]Hard[/]",
        _ => throw new ArgumentOutOfRangeException(
            nameof(difficulty),
            difficulty,
            $"Missing difficulty {difficulty}")
    };
}
