namespace LeetCode.ConsoleApp;

internal record ProblemDetail(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    string Language,
    Uri? Link);