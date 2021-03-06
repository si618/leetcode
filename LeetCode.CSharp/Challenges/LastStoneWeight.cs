namespace LeetCode;

using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

public sealed partial class Challenge
{
    [LeetCode("Last Stone Weight", Difficulty.Easy, Category.HeapPriorityQueue)]
    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    public static int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> queue = new();
        foreach (var stone in stones)
        {
            queue.Enqueue(stone, -stone);
        }

        while (queue.Count > 1)
        {
            var heaviest = queue.Dequeue();
            var nextHeaviest = queue.Dequeue();
            if (heaviest == nextHeaviest)
            {
                continue;
            }
            var remainder = heaviest - nextHeaviest;
            queue.Enqueue(remainder, -remainder);
        }

        return queue.Count == 0 ? 0 : queue.Peek();
    }

    [Test]
    public void LastStoneWeightTest()
    {
        var ex1 = new[] { 2, 7, 4, 1, 8, 1 };
        var ex2 = new[] { 1 };

        LastStoneWeight(ex1).Should().Be(1);
        LastStoneWeight(ex2).Should().Be(1);
    }
}
