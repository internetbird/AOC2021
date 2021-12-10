using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class BasicFuelCostStrategy : IFuelCostStrategy
    {
        public int CalculateCostForPosition(List<int> positions, int positionToCalculate)
        {
            int totalCost = positions.Sum(position => Math.Abs(position - positionToCalculate));
            return totalCost;
        }
    }
}
