using AOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day1PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day1.txt");

            int numOfDepthIncrease = 0;
            int prevValue = int.Parse(inputLines[0]);

            for (int i = 1; i < inputLines.Length; i++)
            {
                int currValue = int.Parse(inputLines[i]);

                if (currValue > prevValue)
                {
                    numOfDepthIncrease++;
                }

                prevValue = currValue;
            }

            return numOfDepthIncrease.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day1.txt");

            int numOfDepthIncrease = 0;

            int prevSum = int.Parse(inputLines[0]) + int.Parse(inputLines[1]) + int.Parse(inputLines[2]);

            for (int i = 1; i < inputLines.Length - 2; i++)
            {
                int currSum = int.Parse(inputLines[i]) + int.Parse(inputLines[i+1]) + int.Parse(inputLines[i + 2]);

                if (currSum > prevSum)
                {
                    numOfDepthIncrease++;
                }

                prevSum = currSum;
            }

            return numOfDepthIncrease.ToString();
        }
    }
}
