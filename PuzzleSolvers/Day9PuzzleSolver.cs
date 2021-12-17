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
            int[,] map = GetInputMap();

            Dictionary<Point, int> lowPointsDict = FindAllLowPoints(map);

            return lowPointsDict.Sum(kvp => kvp.Value + 1).ToString();
        }

        private static int[,] GetInputMap(string inputFileName = "day9.txt")
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines(inputFileName);

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

            return map;
        }

        private Dictionary<Point, int> FindAllLowPoints(int[,] map)
        {

            var lowPointsDict = new Dictionary<Point, int>();

            int numOfRows = map.GetLength(0);
            int numOfColumns = map.GetLength(1);

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    Dictionary<Point, int> neighboursDict = GetAllNeighbours(i, j, map);

                    int currVal = map[i, j];

                    if (neighboursDict.All(kvp => kvp.Value > currVal))
                    {
                        lowPointsDict.Add(new Point(i, j), currVal);
                    }
                }
            }

            return lowPointsDict;
        }

        private Dictionary<Point, int> GetAllNeighbours(int x, int y, int[,] map)
        {

            var allNeighbours = new Dictionary<Point, int>();

            int numOfRows = map.GetLength(0);
            int numOfColumns = map.GetLength(1);

            List<Point> neighbourPoints = GetNeighbourCoordinates(x, y);

            foreach (Point point in neighbourPoints)
            {
                if (point.X >= 0 && point.X < numOfRows && point.Y >= 0 && point.Y < numOfColumns)
                {
                    allNeighbours.Add(point, map[point.X, point.Y]);
                }
            }

            return allNeighbours;
        }


        
        private List<Point> GetNeighbourCoordinates(int x, int y)
        {
            var neighbourPoints = new List<Point>();

            neighbourPoints.Add(new Point(x, y + 1));
            neighbourPoints.Add(new Point(x, y - 1));
            neighbourPoints.Add((new Point(x + 1, y)));
            neighbourPoints.Add(((new Point(x - 1, y))));

            return neighbourPoints;
        }

        public string SolvePuzzlePart2()
        {

            int[,] map = GetInputMap("day9.txt");
            var basinSizes = new List<int>();
            Dictionary<Point, int> lowPointsDict = FindAllLowPoints(map);

            foreach (KeyValuePair<Point, int> kvp in lowPointsDict)
            {
                int basinSize = GetBasinSizeForLowPoint(kvp.Key, map);
                basinSizes.Add(basinSize);
            }

            basinSizes = basinSizes.OrderByDescending(s => s).ToList();

            return (basinSizes[0] * basinSizes[1] * basinSizes[2]).ToString();
        }

        private int GetBasinSizeForLowPoint(Point lowPoint, int[,] map)
        {
            List<Point> basin = new List<Point> { lowPoint };

            Dictionary<Point, int> lowPointsDict = GetAllNeighbours(lowPoint.X, lowPoint.Y, map);
            List<Point> pointsToScan = new List<Point>();

            foreach (KeyValuePair<Point, int> kvp in lowPointsDict)
            {
                if (kvp.Value != 9)
                {
                    basin.Add(kvp.Key);
                    pointsToScan.Add(kvp.Key);
                }
            }

            while (pointsToScan.Any())
            {
                var scannedPoints = new List<Point>();
                var newPointsToScan = new List<Point>();

                foreach (Point point in pointsToScan)
                {
                    Dictionary<Point, int> neighbours = GetAllNeighbours(point.X, point.Y, map);

                    foreach (KeyValuePair<Point, int> kvp in neighbours)
                    {
                        if ((map[point.X, point.Y] < kvp.Value)
                            && (kvp.Value != 9)
                            && !basin.Contains(kvp.Key))
                        {
                            basin.Add(kvp.Key);
                            newPointsToScan.Add(kvp.Key);

                        }
                    }

                    scannedPoints.Add(point);
                }

                pointsToScan.RemoveAll(point => scannedPoints.Contains(point));
                pointsToScan.AddRange(newPointsToScan);
            }

            return basin.Count;
        }
    }
}
