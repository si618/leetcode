namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Add Two Numbers",
        Difficulty.Easy,
        Category.LinkedList,
        "https://www.youtube.com/watch?v=wgFPrzTjm7s")]
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

    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(
        new[] { 9, 9, 9, 9, 9, 9, 9 },
        new[] { 9, 9, 9, 9 },
        new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void AddTwoNumbersTest(int[] list1, int[] list2, int[] expectedList)
    {
        var listNode1 = new ListNode(list1);
        var listNode2 = new ListNode(list2);
        var expectedNode = new ListNode(expectedList);
        var result = AddTwoNumbers(listNode1, listNode2);
        result.ShouldNotBeNull();
        AssertEqual(result, expectedNode);

        return;

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
                l1.val.ShouldBe(l2.val);
                l1 = l1.next;
                l2 = l2.next;
            }
        }
    }
}
