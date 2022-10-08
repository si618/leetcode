namespace LeetCode.FSharp.Problems

open FsUnit
open LeetCode.CSharp
open Xunit

module ContainsDuplicate =

    [<LeetCode("Contains Duplicate", Difficulty.Easy, Category.ArraysAndHashing)>]
    let ContainsDuplicate nums =
        // TODO: Inefficient compared to C# solution
        let numsArray = Seq.toArray nums
        let distinct = Seq.distinct nums
        let result = Seq.toArray distinct
        result.Length < numsArray.Length

    let ex1 = [| 1; 2; 3; 1 |]
    let ex2 = [| 1; 2; 3; 4 |]
    let ex3 = [| 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 |]

    [<Fact>]
    let ``When passing ex1 ContainsDuplicate should return true`` () =
        ContainsDuplicate(ex1) |> should equal true

    [<Fact>]
    let ``When passing ex2 ContainsDuplicate should return false`` () =
        ContainsDuplicate(ex2) |> should equal false

    [<Fact>]
    let ``When passing ex3 ContainsDuplicate should return true`` () =
        ContainsDuplicate(ex3) |> should equal true
