namespace LeetCode.CSharp.Problems;

using System.Collections.Generic;
using System.Linq;

public sealed partial class Problem
{
    [LeetCode("Palindrome Linked List",
        Difficulty.Easy,
        Category.TwoPointers,
        "https://www.youtube.com/watch?v=jJXJ16kPFWg")]
    public static bool IsPalindrome(ListNode head)
    {
        if (head.next is null)
        {
            return true;
        }

        var list = new List<int> { head.val };

        while (head.next is not null)
        {
            head = head.next;
            list.Add(head.val);
        }

        var isOdd = list.Count % 2 != 0;
        var take = isOdd ? (list.Count - 1) / 2 : list.Count / 2;
        var skip = isOdd ? take + 1 : take;
        var firstHalf = list.Take(take).ToArray();
        var secondHalf = list.Skip(skip).Take(take).Reverse().ToArray();

        return !firstHalf.Where((t, i) => t != secondHalf[i]).Any();
    }

    [Fact]
    public void IsPalindromeTest()
    {
        var single = new ListNode(1);
        var even = new ListNode(new[] { 1, 2, 2, 1 });
        var odd = new ListNode(new[] { 1, 2, 3, 2, 1 });
        var notEven = new ListNode(new[] { 2, 1, 2, 1 });
        var notOdd = new ListNode(new[] { 2, 1, 3, 2, 1 });

        IsPalindrome(single).ShouldBeTrue();
        IsPalindrome(even).ShouldBeTrue();
        IsPalindrome(odd).ShouldBeTrue();
        IsPalindrome(notEven).ShouldBeFalse();
        IsPalindrome(notOdd).ShouldBeFalse();
    }
}
