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
    public string Language(string join = " ") =>
        string.Join(join,
                CSharp ? "C#" : string.Empty,
                FSharp ? "F#" : string.Empty)
            .Trim();

    public string LanguageMarkup(string join = " ") =>
        string.Join(join,
                CSharp ? "[blue]C#[/]" : string.Empty,
                FSharp ? "[teal]F#[/]" : string.Empty)
            .Trim();
}