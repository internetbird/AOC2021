using AOC2021.Models;
using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day2PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var submarine = new Submarine();

            string[] inputLines = InputFilesHelper.GetInputFileLines("day2.txt");

            foreach (string line in inputLines)
            {
               string[] lineParts = line.Split(' ');

                int unit = int.Parse(lineParts[1]);

                if (lineParts[0] == "forward")
                {
                    submarine.MoveForward(unit);

                } else if (lineParts[0] == "down")
                {
                    submarine.MoveDown(unit);
                } else
                {
                    submarine.MoveUp(unit); 
                }
            }

            (int depth, int position) = submarine.GetStatus();

            return (depth * position).ToString();
        }

        public string SolvePuzzlePart2()
        {
            var submarine = new AdvancedSubmarine();

            string[] inputLines = InputFilesHelper.GetInputFileLines("day2.txt");

            foreach (string line in inputLines)
            {
                string[] lineParts = line.Split(' ');

                int unit = int.Parse(lineParts[1]);

                if (lineParts[0] == "forward")
                {
                    submarine.MoveForward(unit);

                }
                else if (lineParts[0] == "down")
                {
                    submarine.MoveDown(unit);
                }
                else
                {
                    submarine.MoveUp(unit);
                }
            }

            (int depth, int position) = submarine.GetStatus();

            return (depth * position).ToString();
        }
    }
}
