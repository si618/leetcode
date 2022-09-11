## LeetCode via NeetCode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions for [LeetCode](https://leetcode.com) problems with naïve F# solutions on my functional programming journey.

After stumbling across the excellent [NeetCode](https://neetcode.io) website I'm now following the author's guidance and supporting his work by becoming a lifetime pro 🙇‍
### Building

``` bash
> git --version
git version 2.37.1

> dotnet --list-sdks
6.0.400 [/usr/share/dotnet/sdk]

> git clone https://github.com/si618/leetcode.git
Cloning into 'leetcode'...

> cd leetcode
> dotnet build
> dotnet test --no-restore

```

### Running benchmarks locally

``` bash
# Run all C# and F# benchmarks
> ./Benchmark.ps1
    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/

// Validating benchmarks:
// ***** BenchmarkRunner: Start   *****
...

# List solved C# problems without running benchmarks
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj -f net6.0 --problems

# Show problem details without running benchmarks
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj -f net6.0 --problem 'LRU Cache'

# Run all F# benchmarks
> dotnet run --project Benchmarks.FSharp/Benchmarks.FSharp.fsproj -f net6.0 -c Release --filter *Benchmarks*

# Run single C# benchmark
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj -f net6.0 -c Release --filter *LRUCache
```

### Running benchmarks from docker

``` bash
# Build docker images for C# and F# benchmark projects
> docker-compose up

# List solved C# problems without running benchmarks
> docker run --rm benchmarks-csharp --problems

# Show problem details without running benchmarks
> docker run --rm benchmarks-csharp --problem 'LRU Cache'

# Run all F# benchmarks
> docker run benchmarks-fsharp --filter *Benchmarks*

# Run single C# benchmark
> docker run benchmarks-csharp --filter *LRUCache
```

C# benchmarks have options to list summary of problems as well as problem details.

```
> .\Benchmarks.CSharp.exe --help
Description:
  Benchmark C# LeetCode problems using BenchmarkDotNet
  See: https://benchmarkdotnet.org/articles/guides/console-args.html

Usage:
  Benchmarks.CSharp [options] [[--] <additional arguments>...]]

Options:
  --problems           Show problem summary without running benchmarks
  --problem <problem>  Show details for problem without running benchmarks
  --version            Show version information
  -?, -h, --help       Show help and usage information

Additional Arguments:
  Arguments passed to the application that is being run.
```