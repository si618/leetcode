namespace LeetCode.FSharp.Problems

open FsUnit.Xunit
open LeetCode.CSharp
open Xunit

module FizzBuzz =

    [<LeetCode("Fizz Buzz", Difficulty.Easy, Category.NotInNeetCode)>]
    let FizzBuzz n =
        [ 1..n ]
        |>
        // TODO: Append Buzz to Fizz instead multiple operations
        Seq.map (function
            | x when x % 5 = 0 && x % 3 = 0 -> "FizzBuzz"
            | x when x % 3 = 0 -> "Fizz"
            | x when x % 5 = 0 -> "Buzz"
            | x -> string x)

    [<Fact>]
    let ``When passing 3 FizzBuzz should return expected result`` () =
        FizzBuzz(3)
        |> Seq.toList
        |> should equal [ "1"; "2"; "Fizz" ]

    [<Fact>]
    let ``When passing 5 FizzBuzz should return expected result`` () =
        FizzBuzz(5)
        |> Seq.toList
        |> should equal [ "1"; "2"; "Fizz"; "4"; "Buzz" ]

    [<Fact>]
    let ``When passing 15 FizzBuzz should return expected result`` () =
        FizzBuzz(15)
        |> Seq.toList
        |> should
            equal
            [ "1"
              "2"
              "Fizz"
              "4"
              "Buzz"
              "Fizz"
              "7"
              "8"
              "Fizz"
              "Buzz"
              "11"
              "Fizz"
              "13"
              "14"
              "FizzBuzz" ]
