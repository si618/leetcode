namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("Add Two Numbers", Difficulty.Easy, Category.LinkedList)]
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // Placeholder node to store result
        var result = new ListNode();
        // Node to store sum of nodes
        var answer = result;
        var carry = 0;

        // Process until both nodes are fully evaluated
        while (l1 is not null || l2 is not null)
        {
            var l1Val = 0;
            if (l1 is not null)
            {
                l1Val = l1.val;
                l1 = l1.next!;
            }
            var l2Val = 0;
            if (l2 is not null)
            {
                l2Val = l2.val;
                l2 = l2.next!;
            }
            var sum = l1Val + l2Val + carry;
            carry = sum / 10;
            // New node only stores first digit as carry is saved
            var node = new ListNode(sum % 10);
            // Update both current and next answer to new node
            answer = answer.next = node;
        }

        if (carry > 0)
        {
            answer.next = new ListNode(carry);
        }

        // Answer is guaranteed to be non-null
        return result.next!;
    }

    [Test]
    public void AddTwoNumbersTest()
    {
        var ex11 = new ListNode(new[] { 2, 4, 3 });
        var ex12 = new ListNode(new[] { 5, 6, 4 });
        var ex1Expected = new ListNode(new[] { 7, 0, 8 });
        var ex21 = new ListNode();
        var ex22 = new ListNode();
        var ex2Expected = new ListNode();
        var ex31 = new ListNode(new[] { 9, 9, 9, 9, 9, 9, 9 });
        var ex32 = new ListNode(new[] { 9, 9, 9, 9 });
        var ex3Expected = new ListNode(new[] { 8, 9, 9, 9, 0, 0, 0, 1 });

        var ex1Result = AddTwoNumbers(ex11, ex12);
        var ex2Result = AddTwoNumbers(ex21, ex22);
        var ex3Result = AddTwoNumbers(ex31, ex32);

        ex1Result.Should().NotBeNull();
        ex2Result.Should().NotBeNull();
        ex3Result.Should().NotBeNull();
        static void AssertEqual(ListNode? l1, ListNode? l2)
        {
            while (true)
            {
                if (l1 is null && l2 is null)
                {
                    return;
                }
                if (l1 is null || l2 is null)
                {
                    Assert.Fail("Either both nodes or neither node should be null");
                    return;
                }
                l1.val.Should().Be(l2.val);
                l1 = l1.next;
                l2 = l2.next;
            }
        }
        AssertEqual(ex1Result, ex1Expected);
        AssertEqual(ex2Result, ex2Expected);
        AssertEqual(ex3Result, ex3Expected);
    }
}
