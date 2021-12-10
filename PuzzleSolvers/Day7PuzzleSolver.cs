using AOC2021.Models;
using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day7PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string input = InputFilesHelper.GetInputFileText("day7.txt");

            List<int> positions = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var calculator = new OptimalFuelCalculator(positions, new BasicFuelCostStrategy());
            (int alignPosition, int minFuelCost) = calculator.FindOptimalFuelPosition();
        
            return minFuelCost.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string input = InputFilesHelper.GetInputFileText("day7.txt");

            List<int> positions = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var calculator = new OptimalFuelCalculator(positions, new AdvancedFuelCostStrategy());
            (int alignPosition, int minFuelCost) = calculator.FindOptimalFuelPosition();

            return minFuelCost.ToString();
        }
    }
}
