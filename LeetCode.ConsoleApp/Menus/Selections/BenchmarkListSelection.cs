﻿namespace LeetCode.ConsoleApp.Menus.Selections;

internal sealed record BenchmarkListSelection : Selection
{
    internal BenchmarkListSelection(int order) : base("Run Benchmarks", order)
    {
    }

    public override int Execute()
    {
        AnsiConsole.Write("TODO: Multi selection prompt to run all or selected benchmarks in C# or F#");

        Console.ReadLine();

        return 0;
    }
}