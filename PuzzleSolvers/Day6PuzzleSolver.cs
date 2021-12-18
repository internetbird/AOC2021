using AOC;
using AOC2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day6PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string input = InputFilesHelper.GetInputFileText("day6.txt");
           
            List<int> population = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var simulator = new LanternfishSimulator(population);

            simulator.Simulate(80);

            return simulator.GetPopulationSize().ToString();
        }

        public string SolvePuzzlePart2()
        {
            string input = InputFilesHelper.GetInputFileText("day6.txt");

            List<int> population = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var simulator = new LanternfishSimulator(population);

            simulator.SimulateWithCounters(256);

            return simulator.GetPopulationSizeByCounters().ToString();
        }
    }
}
