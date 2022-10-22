namespace LeetCode;

internal record Problem(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    Uri? Link,
    bool CSharp,
    bool FSharp)
{
    public string Language(string join = " ") =>
        CSharp && FSharp
            ? string.Join(join, "C#", "F#")
            : CSharp
                ? "C#"
                : FSharp
                    ? "F#"
                    : string.Empty;

    public string LanguageMarkup(string join = " ") =>
        CSharp && FSharp
            ? string.Join(join, "[blue]C#[/]", "[teal]F#[/]")
            : CSharp
                ? "[blue]C#[/]"
                : FSharp
                    ? "[teal]F#[/]"
                    : string.Empty;
}