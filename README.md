## Leetcode via Neetcode
[![Build and Benchmark](https://github.com/si618/leetcode/actions/workflows/workflow.yml/badge.svg)](https://github.com/si618/leetcode/actions/workflows/workflow.yml)

[Benchmarked](https://si618.github.io/leetcode/dev/bench) C# submissions to [Leetcode](https://leetcode.com) challenges with naïve F# solutions on my functional programming journey.

I stumbled across the most excellent [Neetcode](https://neetcode.io) website and am now following the author's guidance.

### Building

```
> git --version
git version 2.37.1

> dotnet --list-sdks
6.0.303 [/usr/share/dotnet/sdk]

> git clone https://github.com/si618/leetcode.git
Cloning into 'leetcode'...

> cd leetcode
> dotnet build
> dotnet test --no-restore
> ./Benchmark.ps1
LeetCode C# Challenges
```

Github [workflow](https://github.com/si618/leetcode/actions/workflows/workflow.yml) may help if you run into issues.
