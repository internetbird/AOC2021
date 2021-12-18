using AOC;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day11PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfFlashes = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day11.txt");

            var owl = new MatrixOwl();

            int[,] map = owl.ParseIntMatrix(inputLines);




            return numOfFlashes.ToString();

        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
