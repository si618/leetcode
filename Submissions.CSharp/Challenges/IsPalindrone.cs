namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public sealed partial class Submission
{
    [LeetCode("Palindrome Linked List", Difficulty.Easy, Category.TwoPointers)]
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
        };

        var isOdd = list.Count % 2 != 0;
        var take = isOdd ? (list.Count - 1) / 2 : list.Count / 2;
        var skip = isOdd ? take + 1 : take;
        var firstHalf = list.Take(take).ToArray();
        var secondHalf = list.Skip(skip).Take(take).Reverse().ToArray();

        // ReSharper disable once LoopCanBeConvertedToQuery
        for (var i = 0; i < firstHalf.Length; i++)
        {
            if (firstHalf[i] != secondHalf[i])
            {
                return false;
            }
        }

        return true;
    }

    [Test]
    public void IsPalindromeTest()
    {
        var single = new ListNode(1);
        var even = new ListNode(1,
            new ListNode(2,
            new ListNode(2,
            new ListNode(1))));
        var odd = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(2,
            new ListNode(1)))));
        var notEven = new ListNode(2,
            new ListNode(1,
            new ListNode(2,
            new ListNode(1))));
        var notOdd = new ListNode(2,
            new ListNode(1,
            new ListNode(3,
            new ListNode(2,
            new ListNode(1)))));

        IsPalindrome(single).Should().BeTrue();
        IsPalindrome(even).Should().BeTrue();
        IsPalindrome(odd).Should().BeTrue();
        IsPalindrome(notEven).Should().BeFalse();
        IsPalindrome(notOdd).Should().BeFalse();
    }
}
