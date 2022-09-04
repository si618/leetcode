namespace Benchmarks.CSharp;

internal record ProblemDetail(
    string Name,
    string Description,
    Category Category,
    Difficulty Difficulty,
    Uri? Link);
