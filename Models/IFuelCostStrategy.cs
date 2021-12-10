using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.Models
{
    public interface IFuelCostStrategy
    {
        public int CalculateCostForPosition(List<int> positions, int positionToCalculate);
    }
}
