using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class OptimalFuelCalculator
    {
        private List<int> _positions;
        private IFuelCostStrategy _costStrategy;


        public OptimalFuelCalculator(List<int> positions, IFuelCostStrategy costStrategy)
        {
            _positions = positions;
            _costStrategy = costStrategy;
        }

        public (int alignPosition, int minFuelCost) FindOptimalFuelPosition()
        {
            int positionAverage = (int)_positions.Average();

            (int alignPositionUp, int minFuelCostUp) = SearchOptimal(positionAverage, 1);
            (int alignPositionDown, int minFuelCostDown) = SearchOptimal(positionAverage, -1);

            if (minFuelCostDown < minFuelCostUp)
            {
                return (alignPositionDown, minFuelCostDown);
            } else
            {
                return (alignPositionUp, minFuelCostUp);
            }
        }


        private (int alignPositionUp, int minFuelCostUp) SearchOptimal(int positionAverage, int step)
        {
            int optimalPosition = positionAverage;
            int searchPosition = positionAverage;
            int minFuelCost = CalculateCostForPosition(positionAverage);

            bool continueSearching = true;

            while (continueSearching)
            {
               searchPosition = searchPosition + step;
                int searchPositionCost = CalculateCostForPosition(searchPosition);

                if (searchPositionCost > minFuelCost)
                {
                    continueSearching = false;
                } else
                {
                    optimalPosition = searchPosition;
                    minFuelCost = searchPositionCost;
                }
            }

            return (optimalPosition , minFuelCost);
        }

        private int CalculateCostForPosition(int alignPosition)
        {
            return _costStrategy.CalculateCostForPosition(_positions, alignPosition);
        }
    }
}
