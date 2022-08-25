## Leetcode via Neetcode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions for [Leetcode](https://leetcode.com) problems with naïve F# solutions on my functional programming journey.

I stumbled across the most excellent [Neetcode](https://neetcode.io) website and am now following the author's approach.

### Building

```
> git --version
git version 2.37.1

> dotnet --list-sdks
6.0.400 [/usr/share/dotnet/sdk]

> git clone https://github.com/si618/leetcode.git
Cloning into 'leetcode'...

> cd leetcode
> dotnet build
> dotnet test --no-restore
> ./Benchmark.ps1
    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/

Solved C# Problems

...
```
