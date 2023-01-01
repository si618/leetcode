namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Top K Frequent Elements",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=YPTqKIgVk-k")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int[] TopKFrequent(int[] nums, int k)
    {
        // Benchmarking showed setting capacity to maximum resulted in faster execution and around
        // half the memory allocation for large length of nums
        var frequency = new Dictionary<int, int>(nums.Length);

        foreach (var num in nums)
        {
            // ContainsKey will warn on CA1854 and benchmarking showed virtually no difference
            if (frequency.TryGetValue(num, out _))
            {
                frequency[num]++;
            }
            else
            {
                frequency.Add(num, 1);
            }
        }

        // Benchmarking showed linq solution around twice as slow but slightly more memory efficient
        // return dictionary
        //     .OrderByDescending(n => n.Value)
        //     .Take(k)
        //     .Select(n => n.Key)
        //     .ToArray();

        var sortedFrequency = new PriorityQueue<int, int>(frequency.Count);

        foreach (var kvp in frequency)
        {
            sortedFrequency.Enqueue(kvp.Key, kvp.Value);

            // Remove unwanted result after sorting is done
            if (sortedFrequency.Count > k)
            {
                sortedFrequency.Dequeue();
            }
        }

        var result = new int[k];

        // Loop backwards as priority queue dequeues lowest frequencies first
        for (var i = sortedFrequency.Count - 1; i >= 0; i--)
        {
            result[i] = sortedFrequency.Dequeue();
        }

        return result;
    }

    [Fact]
    public void TopKFrequentTest()
    {
        var ex1 = new[] { 1, 1, 1, 2, 2, 3 };
        var ex1Expected = new[] { 1, 2 };
        var ex2 = new[] { 1 };
        var ex3 = Array.Empty<int>();

        TopKFrequent(ex1, 2).Should().Equal(ex1Expected);
        TopKFrequent(ex2, 1).Should().Equal(ex2);
        TopKFrequent(ex3, 0).Should().Equal(ex3);
    }
}
