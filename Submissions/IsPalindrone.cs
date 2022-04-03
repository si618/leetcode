namespace Leetcode.Submissions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class IsPalindromeTest
{
    public static bool IsPalindrome(ListNode head)
    {
        if (head.Next is null)
        {
            return true;
        }
        var list = new List<int> { head.Val };
        while (head.Next is not null)
        {
            head = head.Next;
            list.Add(head.Val);
        };

        var isOdd = list.Count % 2 != 0;
        var take = isOdd
            ? (list.Count - 1) / 2
            : list.Count / 2;
        var skip = isOdd
            ? take + 1
            : take;
        var firstHalf = new List<int>(list.Take(take));
        var secondHalf = new List<int>(list
            .Skip(skip)
            .Take(take)
            .Reverse());
        for (var i = 0; i < firstHalf.Count; i++)
        {
            if (firstHalf[i] != secondHalf[i])
            {
                return false;
            }
        }
        return true;
    }

    [Test]
    public void Test()
    {
        // Arrange
        var single = new ListNode(1, null);
        var even = new ListNode(1,
            new ListNode(2,
                new ListNode(2,
                    new ListNode(1, null))));
        var odd = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(2,
                        new ListNode(1, null)))));
        var notEven = new ListNode(2,
            new ListNode(1,
                    new ListNode(2,
                        new ListNode(1, null))));
        var notOdd = new ListNode(2,
            new ListNode(1,
                new ListNode(3,
                    new ListNode(2,
                        new ListNode(1, null)))));
        // Act & Assert
        Assert.IsTrue(IsPalindrome(single));
        Assert.IsTrue(IsPalindrome(even));
        Assert.IsTrue(IsPalindrome(odd));
        Assert.IsFalse(IsPalindrome(notEven));
        Assert.IsFalse(IsPalindrome(notOdd));
    }

}
