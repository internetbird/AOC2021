using AOC2021.Models;
using AOC2021.Parsers;
using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day5PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day5.txt");

            var parser = new HydrothermalMapParser();

            HydrothermalMap map = parser.ParseStaritLines(inputLines);

            return map.GetNumOfTwoOrMoreOverlap().ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day5.txt");

            var parser = new HydrothermalMapParser();

            HydrothermalMap map = parser.ParseAllLines(inputLines);

            return map.GetNumOfTwoOrMoreOverlap().ToString();
        }
    }
}
