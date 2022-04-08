namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // Placeholder node to store result
        var result = new ListNode(0);
        // Node to store sum of nodes
        var answer = result;
        var carry = 0;

        // Process until both nodes are fully evaluated
        while (l1 is not null || l2 is not null)
        {
            var l1val = 0;
            if (l1 is not null)
            {
                l1val = l1.val;
                l1 = l1.next!;
            }
            var l2val = 0;
            if (l2 is not null)
            {
                l2val = l2.val;
                l2 = l2.next!;
            }
            var sum = l1val + l2val + carry;
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
        var ex1l1 = new ListNode(2,
            new ListNode(4,
            new ListNode(3, null)));
        var ex1l2 = new ListNode(5,
            new ListNode(6,
            new ListNode(4, null)));
        var ex1expected = new ListNode(7,
            new ListNode(0,
            new ListNode(8, null)));
        var ex2l1 = new ListNode(0, null);
        var ex2l2 = new ListNode(0, null);
        var ex2expected = new ListNode(0, null);
        var ex3l1 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9, null)))))));
        var ex3l2 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9, null))));
        var ex3expected = new ListNode(8,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(0,
            new ListNode(0,
            new ListNode(0,
            new ListNode(1, null))))))));

        var ex1result = AddTwoNumbers(ex1l1, ex1l2);
        var ex2result = AddTwoNumbers(ex2l1, ex2l2);
        var ex3result = AddTwoNumbers(ex3l1, ex3l2);

        ex1result.Should().NotBeNull();
        ex2result.Should().NotBeNull();
        ex3result.Should().NotBeNull();
        static void AssertEqual(ListNode? l1, ListNode? l2)
        {
            if (l1 is null && l2 is null)
            {
                return;
            }
            if (l1 is null || l2 is null)
            {
                Assert.Fail("Either both node or neither node should be null");
                return;
            }
            l1.val.Should().Be(l2.val);
            AssertEqual(l1.next, l2.next);
        }
        AssertEqual(ex1result, ex1expected);
        AssertEqual(ex2result, ex2expected);
        AssertEqual(ex3result, ex3expected);
    }
}
