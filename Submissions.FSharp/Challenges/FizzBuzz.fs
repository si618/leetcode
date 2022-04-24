module LeetCode.FizzBuzz

open FsUnit
open NUnit.Framework

[<LeetCode("Fizz Buzz", Difficulty.Easy, Category.NotInNeetCode)>]
let FizzBuzz n =
    [1 .. n] |>
    // TODO: Append Buzz to Fizz instead multiple operations
    Seq.map (function    
        | x when x % 5 = 0 && x % 3 = 0 -> "FizzBuzz"
        | x when x % 3 = 0 -> "Fizz"
        | x when x % 5 = 0 -> "Buzz"
        | x -> string x)

[<Test>]
let ``When passing 3 FizzBuzz should return expected result`` () =
    FizzBuzz(3) |> should equal ["1"; "2"; "Fizz"]

[<Test>]
let ``When passing 5 FizzBuzz should return expected result`` () =
    FizzBuzz(5) |> should equal ["1"; "2"; "Fizz"; "4"; "Buzz"]

[<Test>]
let ``When passing 15 FizzBuzz should return expected result`` () =
    FizzBuzz(15) |> should equal ["1"; "2"; "Fizz"; "4"; "Buzz"; "Fizz"; "7"; "8"; "Fizz"; "Buzz"; "11"; "Fizz"; "13"; "14"; "FizzBuzz"]