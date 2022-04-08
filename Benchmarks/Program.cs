using BenchmarkDotNet.Running;
using LeetCode;
using System.Reflection;

var benchmarks = typeof(Benchmark).GetMethods().Select(m => m.Name);
var submissions = typeof(Submission)
    .GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static)
    .Where(m => !m.Name.EndsWith("Test"))
    .Select(m => m.Name);
submissions.Except(benchmarks)
    .ToList()
    .ForEach(s => Console.WriteLine($"Benchmark missing for submission `{s}`"));

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);