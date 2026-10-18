using System.Runtime.InteropServices;

namespace LeetCode.CSharp;

// ReSharper disable InconsistentNaming
[StructLayout(LayoutKind.Auto)]
public readonly record struct Interval(int start, int end);
