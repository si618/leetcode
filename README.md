## Leetcode via Neetcode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions for [Leetcode](https://leetcode.com) problems with naïve F# solutions on my functional programming journey.

After stumbling across the excellent [Neetcode](https://neetcode.io) website this repository is now following the author's approach 🙇‍
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

Solved C# Problems

...

# List solved C# problems without running benchmarks
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj --problems

# Show problem details without running benchmarks
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj --problem 'LRU Cache'

Benchmark:    LRUCache
Description:  LRU Cache
Difficulty:   Medium
Category:     Linked List
NeetCode:     https://www.youtube.com/watch?v=7ABFKPK2hD4

# Dry run all benchmarks
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj -c Release --filter *Benchmarks* --job Dry

# Run benchmark with leading asterisk required by BenchmarkDotNet
> dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj -c Release --filter *LRUCache --memory
```

### Running benchmarks from docker

[Dockerfile](https://github.com/si618/leetcode/blob/main/Benchmarks.CSharp/Dockerfile) supports dotnet 6.0 and 7.0 in a Debian 11 container.

Builds are in release configuration and always pass `--memory` argument to BenchmarkDotNet.

``` bash
> docker-compose up

# List available C# problems without running benchmarks
> docker run --rm benchmarks-csharp --problems

# Show problem details without running benchmarks
> docker run --rm benchmarks-csharp --problem 'LRU Cache'

# Dry run all benchmarks targetting dotnet 6.0
> docker run benchmarks-csharp /p:UseTargetFramework=net6.0 --filter *Benchmarks* --job Dry

# Run all C# benchmarks targetting dotnet 7.0
> docker run benchmarks-csharp /p:UseTargetFramework=net7.0 --filter *Benchmarks*

# Run benchmark with leading asterisk required by BenchmarkDotNet
> docker run benchmarks-csharp /p:UseTargetFramework=net7.0 --filter *LRUCache
```
