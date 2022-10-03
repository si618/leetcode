namespace LeetCode.FSharp.Problems

open FsUnit.Xunit
open LeetCode.CSharp

module AddTwoNumbers =

    [<LeetCode("Add Two Numbers", Difficulty.Easy, Category.LinkedList)>]
    let AddTwoNumbers l1 l2 =
        throwWithMessage "TODO"

    let ex11 = ListNode(2,
        ListNode(4,
        ListNode(3, null)))
    let ex12 = ListNode(5,
        ListNode(6,
        ListNode(4, null)))
    let ex1expected = ListNode(7,
        ListNode(0,
        ListNode(8, null)))
    // TODO: [<Fact>]
    let ``When passing example 1 it should return expected result`` () =
        AddTwoNumbers(ex11, ex12) |> should equal ex1expected

    let ex21 = ListNode(0, null)
    let ex22 = ListNode(0, null)
    let ex2expected = ListNode(0, null)
    // TODO: [<Fact>]
    let ``When passing example 2 it should return expected result`` () =
        AddTwoNumbers(ex21, ex22) |> should equal ex2expected

    let ex31 = ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(9, null)))))))
    let ex32 = ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(9, null))))
    let ex3expected = ListNode(8,
        ListNode(9,
        ListNode(9,
        ListNode(9,
        ListNode(0,
        ListNode(0,
        ListNode(0,
        ListNode(1, null))))))))
    // TODO: [<Fact>]
    let ``When passing example 3 it should return expected result`` () =
        AddTwoNumbers(ex31, ex32) |> should equal ex3expected
