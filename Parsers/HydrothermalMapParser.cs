using AOC2021.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2021.Parsers
{
    public class HydrothermalMapParser
    {

        public HydrothermalMap ParseStaritLines(string[] inputLines)
        {
            var map = new HydrothermalMap();

            foreach (string line in inputLines)
            {
                (Point start, Point end) = ParseLine(line);

                if (IsStraitLine(start, end))
                {
                    List<Point> linePoints = GetLinePoints(start, end);

                    foreach (Point point in linePoints)
                    {
                        map.AddPoint(point);
                    }
                }
            }

            return map;
        }

        public HydrothermalMap ParseAllLines(string[] inputLines)
        {
            var map = new HydrothermalMap();

            foreach (string line in inputLines)
            {
                (Point start, Point end) = ParseLine(line);
                List<Point> linePoints = GetLinePoints(start, end);

                foreach (Point point in linePoints)
                {
                    map.AddPoint(point);
                }
            }


            return map;
        }

        private List<Point> GetLinePoints(Point point1, Point point2)
        {
            var points = new List<Point>();

            if (point1.X == point2.X)
            {
                int startY = point1.Y;
                int endY = point2.Y;

                if (point2.Y < point1.Y)
                {
                    startY = point2.Y;
                    endY = point1.Y;
                }

                for (int y = startY; y <= endY; y++)
                {
                    var point = new Point(point1.X, y);
                    points.Add(point);
                }
            }
            else if (point1.Y == point2.Y)
            {
                int startX = point1.X;
                int endX = point2.X;

                if (point2.X < point1.X)
                {
                    startX = point2.X;
                    endX = point1.X;
                }

                for (int x = startX; x <= endX; x++)
                {
                    var point = new Point(x, point1.Y);
                    points.Add(point);
                }
            }
            else //Diagonal line
            {

                int xDiff = point1.X - point2.X;
                int yDiff = point1.Y - point2.Y;

                if (xDiff < 0)
                {
                    int y = point1.Y;

                    for (int x = point1.X; x <= point2.X; x++)
                    {
                        points.Add(new Point(x, y));

                        if (yDiff > 0)
                        {
                            y--;
                        }
                        else
                        {
                            y++;
                        }

                    }
                }
                else
                {
                    int y = point2.Y;

                    for (int x = point2.X; x <= point1.X; x++)
                    {
                        points.Add(new Point(x, y));

                        if (yDiff > 0)
                        {
                            y++;
                        }
                        else
                        {
                            y--;
                        }
                    }
                }
            }

            return points;

        }

        private bool IsStraitLine(Point start, Point end)
        {
            return start.X == end.X || start.Y == end.Y;
        }

        /// <summary>
        /// Parses a line in the format X1,Y1 -> X2,Y2
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private (Point start, Point end) ParseLine(string line)
        {
            string[] pointParts = line.Split("->");

            string[] startPointParts = pointParts[0].Split(',');
            string[] endPointParts = pointParts[1].Split(',');

            Point start = new Point(int.Parse(startPointParts[0].Trim()), int.Parse(startPointParts[1].Trim()));
            Point end = new Point(int.Parse(endPointParts[0].Trim()), int.Parse(endPointParts[1].Trim()));

            return (start, end);
        }
    }
}
