using AOC2021.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day9PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day9.txt");

            int numOfColumns = inputLines[0].Length;
            int numOfRows = inputLines.Length;

            int[,] map = new int[numOfRows, numOfColumns];

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    map[i, j] = int.Parse(inputLines[i][j].ToString());
                }
            }

            List<int> lowPoints = FindAllLowPoints(map);

            return lowPoints.Sum(point => point + 1).ToString();
        }

        private List<int> FindAllLowPoints(int[,] map)
        {
            var lowPoints = new List<int>();

            int numOfRows = map.GetLength(0);
            int numOfColumns = map.GetLength(1);

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    List<int> neighbours = GetAllNeighbours(i, j, map);

                    int currVal = map[i, j];

                    if (neighbours.All(neighbour => neighbour > currVal))
                    {
                        lowPoints.Add(currVal);
                    }
                }
            }

            return lowPoints;
        }

        private List<int> GetAllNeighbours(int i, int j, int[,] map)
        {
            int numOfRows = map.GetLength(0);
            int numOfColumns = map.GetLength(1);

            var neighbours = new List<int>();

            List<Point> neighbourPoints = GetNeighbourCoordinates(i, j);

            foreach (Point point in neighbourPoints)
            {
                if (point.X >= 0 && point.X < numOfColumns && point.Y >= 0 && point.Y < numOfRows)
                {
                    neighbours.Add(map[point.X, point.Y]);
                }
            }

            return neighbours;
        }

        private List<Point> GetNeighbourCoordinates(int i, int j)
        {
            var neighbourPoints = new List<Point>();

            neighbourPoints.Add(new Point(i, j + 1));
            neighbourPoints.Add(new Point(i, j - 1));
            neighbourPoints.Add((new Point(i+ 1, j + 1)));
            neighbourPoints.Add((new Point(i + 1, j - 1)));
            neighbourPoints.Add((new Point(i + 1, j)));
            neighbourPoints.Add(((new Point(i - 1, j))));
            neighbourPoints.Add(((new Point(i - 1, j + 1))));
            neighbourPoints.Add(((new Point(i - 1, j - 1))));

            return neighbourPoints;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
