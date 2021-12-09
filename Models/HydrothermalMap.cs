using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class HydrothermalMap
    {
        private Dictionary<Point, int> _map;


        public HydrothermalMap()
        {
            _map = new Dictionary<Point, int>();
        }

        public int GetNumOfTwoOrMoreOverlap()
        {
            int overlapCount = _map.Where(keyValue => keyValue.Value > 1).Count();
            return overlapCount;
        }

        public void AddPoint(Point point)
        {
            if (_map.ContainsKey(point))
            {
                _map[point]++;
            }
            else
            {
                _map.Add(point, 1);
            }

        }
    }
}
