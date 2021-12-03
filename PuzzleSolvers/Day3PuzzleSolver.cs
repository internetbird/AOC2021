using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            string gammaRateString = string.Empty;
            string epsilonRateString = string.Empty;
            int numOfLines = inputLines.Length;
           
            for (int i = 0; i < inputLines[0].Length; i++)
            {
                var bitCounter = 0;

                foreach (string line in inputLines)
                {
                    if (line[i] == '1')
                    {
                        bitCounter++;
                    }
                }

                if (bitCounter > numOfLines / 2)
                {
                    gammaRateString += "1";
                    epsilonRateString += "0";
                } else
                {
                    gammaRateString += "0";
                    epsilonRateString += "1";
                }
            }

            var powerConsumption = Convert.ToInt32(gammaRateString, 2)
                * Convert.ToInt32(epsilonRateString, 2);

            return powerConsumption.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            int oxygenGeneratorRating = FindOxygenGeneratorRating(inputLines);
            int co2ScrubberRating = FindCo2ScrubberRating(inputLines);

            return (oxygenGeneratorRating * co2ScrubberRating).ToString();
        }

        private int FindCo2ScrubberRating(string[] inputLines)
        {
            List<string> searchList = new List<string>(inputLines);
            int bitIndex = 0;
            while(searchList.Count > 1)
            {
                (int oneBitCount, int zeroBitCount) = GetCountersForBitIndex(searchList, bitIndex);

                if (oneBitCount < zeroBitCount)
                {
                    searchList = FilterByBitValue('1', bitIndex, searchList);
                }
                else
                {
                    searchList = FilterByBitValue('0', bitIndex, searchList);
                }

                bitIndex++;
            }

            return Convert.ToInt32(searchList[0],2);
        }

        private int FindOxygenGeneratorRating(string[] inputLines)
        {
            List<string> searchList = new List<string>(inputLines);
            int bitIndex = 0;

            while (searchList.Count > 1)
            {
                (int oneBitCount, int zeroBitCount) = GetCountersForBitIndex(searchList, bitIndex);

                if (zeroBitCount > oneBitCount)
                {
                    searchList = FilterByBitValue('0', bitIndex, searchList);
                } else
                {
                    searchList = FilterByBitValue('1', bitIndex, searchList);
                }

                bitIndex++;
            }

            return Convert.ToInt32(searchList[0], 2);
        }

        private List<string> FilterByBitValue(char bitChar, int bitIndex, List<string> searchList)
        {
            var filterdList = searchList.Where((value) => value[bitIndex] == bitChar).ToList();
            return filterdList;
        }

        private (int oneBitCount, int zeroBitCount) GetCountersForBitIndex(List<string> values, int bitIndex)
        {
            int oneBitCount = 0;
            int zeroBitCount = 0;

            foreach (string value in values)
            {
                if (value[bitIndex] == '1')
                {
                    oneBitCount++;  
                } else
                {
                    zeroBitCount++;
                }
            }
            return (oneBitCount, zeroBitCount);
        }
    }
}
