# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Best Practices

When working with this codebase, always follow modern .NET and C# best practices:

- Use latest C# language features (records, pattern matching, nullable reference types, file-scoped namespaces)
- Follow .NET naming conventions and coding standards
- Leverage modern async/await patterns where applicable
- Use `System.Text.Json` for JSON serialization
- Prefer `Span<T>` and `Memory<T>` for performance-critical code
- Use collection expressions and LINQ for data manipulation
- Apply proper error handling with exceptions and Result patterns
- Write clean, readable code with meaningful variable names
- Use nullable reference types and enable all relevant compiler warnings

## Commands

### Build
```bash
dotnet build
```

### Test
```bash
dotnet test --no-restore
```

### Run a single test
```bash
dotnet test --filter "FullyQualifiedName~TwoSumTest"
```

### Run console application
```bash
cd ./LeetCode
dotnet run

# Run specific commands
dotnet run benchmark LRUCache --csharp
dotnet run info MergeTwoLists
dotnet run list
```

## Architecture

This is a LeetCode problem solutions repository with benchmarking capabilities, structured as follows:

### Three main projects:
1. **LeetCode.CSharp** - C# implementations of LeetCode problems with xUnit tests and BenchmarkDotNet benchmarks
2. **LeetCode.FSharp** - F# implementations of selected problems
3. **LeetCode** - Console application for running benchmarks and viewing problem information

### Key architectural patterns:

**Problem Organization**: All C# problems are implemented as static methods in the `Problem` partial class, decorated with `[LeetCode]` attributes containing metadata (description, difficulty, category, NeetCode video link). Each problem includes inline xUnit tests using `[Fact]` attributes.

**Benchmark Structure**: Each problem has a corresponding benchmark class in the Benchmarks folder that inherits from a base `Benchmark` class. Benchmarks use BenchmarkDotNet with GlobalSetup/GlobalCleanup for test data preparation.

**Console Application**: Built with Spectre.Console, provides an interactive menu system and CLI commands (app, benchmark, info, list, workflow) for running benchmarks and viewing problem information.

**Testing**: Uses xUnit with FluentAssertions for test assertions. Tests are co-located with problem implementations for easy access.

**Package Management**: Uses Directory.Packages.props for centralized NuGet package version management across all projects.