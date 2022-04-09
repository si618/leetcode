module Submission

open FsUnit
open NUnit.Framework

let FizzBuzz n =
    [1..n]      // I am the list of numbers 1-n.  
                // F# has immutable singly-linked lists.
                // List literals use square brackets.

    |>          // I am the pipeline operator.  
                // "x |> f" is just another way to write "f x".
                // It is a common idiom to "pipe" data through
                // a bunch of transformative functions.

       Seq.map  // "Seq" means "sequence", in F# such sequences
                // are just another name for IEnumerable<T>.
                // "map" is a function in the "Seq" module that
                // applies a function to every element of a 
                // sequence, returning a new sequence of results.

            (function    
                // The function keyword is one way to
                // write a lambda, it means the same
                // thing as "fun z -> match z with".
                // "fun" starts a lambda.
                // "match expr with" starts a pattern
                // match, that then has |cases.

        | x when x % 5 = 0 && x % 3 = 0
                // I'm a pattern.  The pattern is "x", which is 
                // just an identifier pattern that matches any
                // value and binds the name (x) to that value.
                // The "when" clause is a guard - the pattern
                // will only match if the guard predicate is true.

            -> "FizzBuzz"
                // After each pattern is "-> expr" which is 
                // the thing evaluated if the pattern matches.
                // If this pattern matches, we return that 
                // string literal "FizzBuzz".
        | x when x % 3 = 0 -> "Fizz"
                // Patterns are evaluated in order, just like
                // if...elif...elif...else, which is why we did 
                // the 'divisble-by-both' check first.

        | x when x % 5 = 0 -> "Buzz"
        | x -> string x)
                // "string" is a function that converts its argument
                // to a string.  F# is statically-typed, so all the 
                // patterns have to evaluate to the same type, so the
                // return value of the map call can be e.g. an
                // IEnumerable<string> (aka seq<string>).

    |>          // Another pipeline; pipe the prior sequence into...

       Seq.iter // iter applies a function to every element of a 
                // sequence, but the function should return "unit"
                // (like "void"), and iter itself returns unit.
                // Whereas sequences are lazy, "iter" will "force"
                // the sequence since it needs to apply the function
                // to each element only for its effects.

            (printfn "%s")
                // F# has type-safe printing; printfn "%s" expr
                // requires expr to have type string.  Usual kind of
                // %d for integers, etc.  Here we have partially 
                // applied printfn, it's a function still expecting 
                // the string, so this is a one-argument function 
                // that is appropriate to hand to iter.  Hurrah!

[<Test>]
let ``When passing 3 FizzBuzz should return expected result`` () =
    FizzBuzz(3) |> should equal [1, 2, "Fizz"]

[<Test>]
let ``When passing 5 FizzBuzz should return expected result`` () =
    FizzBuzz(5) |> should equal ["1", "2", "Fizz", "4", "Buzz"]

[<Test>]
let ``When passing 15 FizzBuzz should return expected result`` () =
    FizzBuzz(15) |> should equal ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
        "11", "Fizz", "13", "14", "FizzBuzz"]