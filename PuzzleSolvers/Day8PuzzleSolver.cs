using AOC2021.Models;
using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day8PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int count = 0;

            string[] lines = InputFilesHelper.GetInputFileLines("day8.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                int uniqueDigitsCount = parts[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Count(value => value.Length == 3 || value.Length == 4 || value.Length == 2 || value.Length == 7);
                count += uniqueDigitsCount;

            }

            return count.ToString();

        }

        public string SolvePuzzlePart2()
        {
            int result = 0;

            string[] lines = InputFilesHelper.GetInputFileLines("day8.txt");
            var decoder = new SevenSegementDecoder();

            foreach (string line in lines)
            {
                int decodedValue = decoder.DecodeLine(line);
                result += decodedValue;
            }

            return result.ToString();
        }
    }
}
