namespace LeetCode.ConsoleApp;

internal record ProblemDetail(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    Uri? Link,
    bool CSharp,
    bool FSharp)
{
    public string LanguageMarkup() =>
        string.Join(" ",
                CSharp ? "[blue]C#[/]" : string.Empty,
                FSharp ? "[teal]F#[/]" : string.Empty)
            .Trim();
}