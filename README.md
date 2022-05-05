## Leetcode via Neetcode
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/si618/leetcode/Build%20and%20Benchmark)

[Benchmarked](si618.github.io/leetcode/dev/bench) C# submissions to [Leetcode](leetcode.com) challenges with naïve F# solutions on my functional programming journey.

I stumbled across the most excellent [Neetcode](neetcode.io) website and am now following the author's guidance.

### Building

```
> git --version
git version 2.25.1

> dotnet --list-sdks
6.0.202 [/usr/share/dotnet/sdk]

> git clone https://github.com/si618/leetcode.git
Cloning into 'leetcode'...

> cd leetcode
> dotnet build
> dotnet test --no-restore
> ./Benchmark.ps1
LeetCode C# Challenges
```

Github [workflow](https://github.com/si618/leetcode/actions/workflows/workflow.yml) may help if you run into issues. 
