## LeetCode via NeetCode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions for [LeetCode](https://leetcode.com) problems with naïve F# solutions on my functional programming journey.

After stumbling across the excellent [NeetCode](https://neetcode.io) website I'm now following the author's guidance and supporting his work by becoming a lifetime pro 🙇‍
### Building

``` bash
> dotnet --list-sdks
6.0.402 [/usr/share/dotnet/sdk]

> git --version
git version 2.37.3

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
USAGE:
    LeetCode.exe [OPTIONS] <COMMAND>

EXAMPLES:
    LeetCode.exe benchmark LRUCache --csharp
    LeetCode.exe info MergeTwoLists

OPTIONS:
    -h, --help       Prints help information
    -v, --version    Prints version information

COMMANDS:
    app          Run interactive console application
    benchmark    Run benchmarks against leetcode problems
    info         Show information about a problem
    list         List information about problems
    workflow     Run benchmarks for GitHub workflow

> dotnet run app
    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/

> List Problems
  Run Benchmarks
  About
  Exit
```

### Running benchmarks from docker

``` bash
# Build docker image
> docker compose up

# Run console app
> docker run --rm -it leetcode app

# List solved problems
> docker run --rm leetcode list

# Show problem details
> docker run --rm leetcode info 'climbing stairs'

# Run all F# benchmarks
> docker run leetcode benchmark --fsharp

# Run single C# benchmark
> docker run leetcode benchmark LRUCache --csharp
```
