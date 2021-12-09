using AOC2021.PuzzleSolvers;
using System;

namespace AOC2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day5PuzzleSolver();

            var solution = solver.SolvePuzzlePart2();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
