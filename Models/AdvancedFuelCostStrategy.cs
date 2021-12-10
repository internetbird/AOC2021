using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.Models
{
    public class AdvancedFuelCostStrategy : IFuelCostStrategy
    {
        public int CalculateCostForPosition(List<int> positions, int alignPosition)
        {
           int cost = 0;

            foreach(int position in positions)
            {
                int distance = Math.Abs(alignPosition - position);
                int positionCost = ((distance + 1)*distance)/2; //Sum of arithmetic series

                cost += positionCost;
            }

            return cost;
        }
    }
}
