using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.Models
{
    public class DumboOctopusSimulator
    {
        private int[,] _map;

        public DumboOctopusSimulator(int[,] initialState)
        {
            _map = initialState;
        }

        public int Simulate(int numOfSteps = 100)
        {
            int numOfFlashes = 0;

            while(numOfSteps > 0)
            {
                int stepFlashes = SimulateSingleStep();
                numOfFlashes += stepFlashes;
                numOfSteps--;
            }

            return numOfFlashes;
        }

        private int SimulateSingleStep()
        {
            return 0;
        }
    }
}
