module LeetCode.AddTwoNumbers

open FsUnit
open NUnit.Framework

[<LeetCode("Add Two Numbers", Difficulty.Easy, Category.LinkedList)>]
let AddTwoNumbers l1 l2 =
    throwWithMessage "TODO"

let ex1l1 = new ListNode(2,
    new ListNode(4,
    new ListNode(3, null)))
let ex1l2 = new ListNode(5,
    new ListNode(6,
    new ListNode(4, null)))
let ex1expected = new ListNode(7,
    new ListNode(0,
    new ListNode(8, null)))
// TODO: [<Test>]
let ``When passing example 1 it should return expected result`` () =
    AddTwoNumbers(ex1l1, ex1l2) |> should equal ex1expected

let ex2l1 = new ListNode(0, null)
let ex2l2 = new ListNode(0, null)
let ex2expected = new ListNode(0, null)
// TODO: [<Test>]
let ``When passing example 2 it should return expected result`` () =
    AddTwoNumbers(ex2l1, ex2l2) |> should equal ex2expected

let ex3l1 = new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9, null)))))))
let ex3l2 = new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9, null))))
let ex3expected = new ListNode(8,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(0,
    new ListNode(0,
    new ListNode(0,
    new ListNode(1, null))))))))
// TODO: [<Test>]
let ``When passing example 3 it should return expected result`` () =
    AddTwoNumbers(ex3l1, ex3l2) |> should equal ex3expected
