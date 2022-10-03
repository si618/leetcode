## LeetCode via NeetCode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions for [LeetCode](https://leetcode.com) problems with naïve F# solutions on my functional programming journey.

After stumbling across the excellent [NeetCode](https://neetcode.io) website I'm now following the author's guidance and supporting his work by becoming a lifetime pro 🙇‍
### Building

``` bash
> git --version
git version 2.37.1

> dotnet --list-sdks
6.0.401 [/usr/share/dotnet/sdk]

> git clone https://github.com/si618/leetcode.git
Cloning into 'leetcode'...

> cd leetcode
> dotnet build
> dotnet test --no-restore

```

### Console Application

Problem information and benchmarks can be run from the console application

``` bash
> cd ./LeetCode.ConsoleApp
> dotnet run
    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/
```

### Running benchmarks from docker

``` bash
# Build docker image
> docker compose up

# List solved problems without running benchmarks
> docker run --rm leetcode --problems

# Show problem details without running benchmarks
> docker run --rm leetcode --problem 'LRU Cache'

# Run all F# benchmarks
> docker run leetcode --filter *FSharp.Benchmarks*

# Run single C# benchmark
> docker run leetcode --filter *CSharp.Benchmark.LRUCache
```
