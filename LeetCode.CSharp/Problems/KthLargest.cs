namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Kth Largest Element in a Stream",
        Difficulty.Easy,
        Category.HeapPriorityQueue,
        "https://www.youtube.com/watch?v=hOjcdrqMoQ8")]
    public class KthLargest
    {
        private readonly PriorityQueue<int, int> _queue = new();
        private readonly int _k;

        [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Local")]
        public KthLargest(int k, int[] nums)
        {
            _k = k;
            nums
                .OrderBy(n => n)
                .TakeLast(k)
                .ToList()
                .ForEach(n => _queue.Enqueue(n, n));
        }

        public int Add(int val)
        {
            if (_queue.Count < _k)
            {
                _queue.Enqueue(val, val);
            }
            else if (val > _queue.Peek())
            {
                _queue.Dequeue();
                _queue.Enqueue(val, val);
            }
            return _queue.Peek();
        }
    }

    [Fact]
    public void KthLargestTest()
    {
        var ex1 = new KthLargest(3, new[] { 4, 5, 8, 2 });
        var ex2 = new KthLargest(3, new[] { 4, 5 });

        using (new AssertionScope())
        {
            ex1.Add(3).Should().Be(4, "3 shouldn't replace 4");
            ex1.Add(5).Should().Be(5, "5 should replace 4");
            ex1.Add(10).Should().Be(5, "10 should replace 5");
            ex1.Add(9).Should().Be(8, "9 should replace 8");
            ex1.Add(4).Should().Be(8, "4 shouldn't replace 8");
        }
        using (new AssertionScope())
        {
            ex2.Add(3).Should().Be(3, "3 should be added");
            ex2.Add(5).Should().Be(4, "5 should replace 3");
            ex2.Add(10).Should().Be(5, "10 should replace 5");
            ex2.Add(9).Should().Be(5, "9 should replace 5");
            ex2.Add(4).Should().Be(5, "4 shouldn't replace 5");
        }

    }
}
