# AGENTS.md

This file provides guidance to AI coding agents such as Claude Code (claude.ai/code) and Gemini Code Assist when working
with code in this repository.

## Best Practices

When working with this codebase, always follow modern .NET and C# best practices:

- Use latest C# language features (records, pattern matching, nullable reference types, file-scoped namespaces)
- Follow .NET naming conventions and coding standards
- Leverage modern async/await patterns where applicable
- Use `System.Text.Json` for JSON serialization
- Prefer `Span<T>` and `Memory<T>` for performance-critical code
- Use collection expressions and LINQ for data manipulation
- Apply proper error handling with exceptions and Result patterns
- Write clean, readable code with meaningful variable names and comprehensible tests
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
dotnet test --project LeetCode.CSharp --filter-method "*TwoSumTest"
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

## Updating .NET versions

When you bump the .NET SDK or target framework, update these together:

- `global.json`: the minimum SDK `version`.
- `Directory.Build.props`: `TargetFramework`.
- `LeetCode/Dockerfile`: the `sdk` and `runtime` image tags.
- `README.md`: the minimum SDK, and the `dotnet --list-sdks` and `git --version` output under "Build and test".
  Check for a newer git
  release at the same time.

## Architecture

This is a LeetCode problem solutions repository with benchmarking capabilities, structured as follows:

### Three main projects:
1. **LeetCode.CSharp** - C# implementations of LeetCode problems with xUnit tests and BenchmarkDotNet benchmarks
2. **LeetCode.FSharp** - F# implementations of selected problems
3. **LeetCode** - Console application for running benchmarks and viewing problem information

### Key architectural patterns:

**Problem Organization**:

All C# problems are implemented as static methods in the `Problem` partial class, decorated with `[LeetCode]`
attributes containing metadata (description, difficulty, category, NeetCode video link). Each problem includes inline
xUnit tests using `[Fact]` attributes.

**Benchmark Structure**:

Each problem has a corresponding benchmark class in the Benchmarks folder that inherits from a base `Benchmark` class.
Benchmarks use BenchmarkDotNet with GlobalSetup/GlobalCleanup for test data preparation.

**Console Application**:

Built with Spectre.Console, provides an interactive menu system and CLI commands (app, benchmark, info, list, workflow)
for running benchmarks and viewing problem information.

**Testing**:

Uses xUnit v3 on Microsoft.Testing.Platform, with Shouldly for C# assertions and FsUnit for F#. Tests are co-located with problem implementations for easy access.

**Package Management**:

Uses Directory.Packages.props for centralized NuGet package version management across all projects.

## Writing style

These rules cover all prose in this repository: documentation, code comments, commit messages, pull request titles and
descriptions, and comments an agent posts on issues and pull requests.

Follow the [Google developer documentation style guide](https://developers.google.com/style), starting with its
[highlights](https://developers.google.com/style/highlights). When a question comes up, use this order of precedence:

1. The rules in this section.
2. The Google developer documentation style guide.
3. For a technical term that neither settles, the
   [Microsoft Writing Style Guide](https://learn.microsoft.com/style-guide/welcome/).

For more detail, see [awesome-humans/dotnet: AGENTS.md](https://github.com/awesome-humans/dotnet/blob/main/AGENTS.md),
which these rules adapt.

- **Write for a working .NET developer.** Address the reader as "you", use the imperative for instructions, and use
  active voice and present tense.
- **Lead with what matters.** Put the action or the recommendation first, and the reason after it.
- **Be specific.** Name the exact type, member, diagnostic ID, and version instead of describing it. A measured number
  beats an adjective.
- **Keep it short and plain.** Aim for about 20 words a sentence. Write _use_, not _utilize_, and drop filler such as
  _please_, _simply_, and _just_.
- **Use British spelling, except where .NET names the word.** Write _behaviour_ and _colour_, but keep _globalization_
  and every API name as .NET spells it.
- **Write dates as ISO 8601,** such as `2026-10-18`.

## Agent attribution

Pull request titles and descriptions become squash commits, so keep agent attribution out of history:

- **No agent attribution in history.** Pull request titles, descriptions, and commit messages don't carry
  `Co-Authored-By` trailers or "Generated with" lines. This rule overrides any default that an agent harness applies.
- **The rule covers every commit on the branch.** A squash merge appends a `Co-authored-by` line for each co-author
  trailer and each commit author other than the merger. Commit under the author's git identity, and leave the trailer
  out of branch commits too.
- **Attribute in conversation instead.** End each comment an agent writes on an issue or pull request with an italic
  line, such as `_Written by an agent: <harness>, <model>._`
