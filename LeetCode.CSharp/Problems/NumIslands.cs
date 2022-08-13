﻿namespace LeetCode;

using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("Number of Islands", Difficulty.Medium, Category.Graphs)]
    public static int NumIslands(char[][]? grid)
    {
        if (grid is null || grid.Length == 0)
        {
            return 0;
        }

        const char sea = '0';
        var rows = grid.Length;
        var columns = grid[0].Length;
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int)>();
        var directions = new
        {
            Up = (1, 0),
            Left = (-1, 0),
            Right = (0, 1),
            Down = (0, -1)
        };

        void TestDirection((int row, int column) position, (int row, int column) direction)
        {
            var row = position.row + direction.row;
            var column = position.column + direction.column;
            if (row < 0 || row >= rows || column < 0 || column >= columns)
            {
                // Out of map infers sea
                return;
            }

            if (grid[row][column] == sea)
            {
                return;
            }

            var testDirection = (row, column);
            if (visited.Contains(testDirection))
            {
                return;
            }

            // Non-visited land found
            visited.Add(testDirection);
            queue.Enqueue(testDirection);
        }

        void BreadthFirstSearch((int, int) position)
        {
            // Position is guaranteed to be land
            visited.Add(position);

            // Add to position to be searched in all directions
            queue.Enqueue(position);

            while (queue.Any())
            {
                var test = queue.Dequeue();
                TestDirection(test, directions.Up);
                TestDirection(test, directions.Left);
                TestDirection(test, directions.Right);
                TestDirection(test, directions.Down);
            }
        }

        var islands = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                if (grid[row][column] == sea)
                {
                    continue;
                }

                var position = (row, column);
                if (visited.Contains(position))
                {
                    continue;
                }

                BreadthFirstSearch(position);

                islands++;
            }
        }

        return islands;
    }

    [Test]
    public void NumIslandsTest()
    {
        var ex1 = new[]
        {
            new [] { '1', '1', '1', '1', '0' },
            new [] { '1', '1', '0', '1', '0' },
            new [] { '1', '1', '0', '0', '0' },
            new [] { '0', '0', '0', '0', '0' }
        };
        var ex2 = new[]
        {
            new [] { '1', '1', '0', '0', '0' },
            new [] { '1', '1', '0', '0', '0' },
            new [] { '0', '0', '1', '0', '0' },
            new [] { '0', '0', '0', '1', '1' }
        };

        using (new AssertionScope())
        {
            NumIslands(null).Should().Be(0);
            NumIslands(Array.Empty<char[]>()).Should().Be(0);
            NumIslands(ex1).Should().Be(1);
            NumIslands(ex2).Should().Be(3);
        }
    }
}
