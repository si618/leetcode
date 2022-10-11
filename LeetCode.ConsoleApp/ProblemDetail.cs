namespace LeetCode.ConsoleApp;

public record ProblemDetail(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    string Language,
    Uri? Link);