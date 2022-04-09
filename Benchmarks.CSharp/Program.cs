using BenchmarkDotNet.Running;
using LeetCode;
using System.Reflection;

var benchmarks = typeof(Benchmark).GetMethods().Select(m => m.Name);
var submissionsInCSharp = typeof(Submission)
    .GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static)
    .Where(m => !m.Name.EndsWith("Test"))
    .Select(m => m.Name);
submissionsInCSharp.Except(benchmarks)
    .ToList()
    .ForEach(s => Console.WriteLine($"Benchmark missing for C# submission `{s}`!"));

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);