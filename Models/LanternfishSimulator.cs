using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AOC2021.Models
{
    public class LanternfishSimulator
    {
        private List<int> _fishPopulation;
        private const int MaxFishTimerValue = 9;

        private BigInteger[] _fishPopulationCounters = new BigInteger[MaxFishTimerValue];

        public LanternfishSimulator(List<int> initalPopulation)
        {
            _fishPopulation = initalPopulation;

            foreach (int fish in initalPopulation)
            {
                _fishPopulationCounters[fish]++;
            }
        }

        public void Simulate(int numOfSteps)
        {
            while (numOfSteps > 0)
            {

                List<int> nextGenerationPopulation = new List<int>();

                foreach (int fish in _fishPopulation)
                {
                    if (fish == 0)
                    {
                        nextGenerationPopulation.Add(6); //parent
                        nextGenerationPopulation.Add(8); //child
                    }
                    else
                    {
                        nextGenerationPopulation.Add(fish - 1);
                    }

                }

                _fishPopulation = nextGenerationPopulation;

                numOfSteps--;
            }
        }


        public void SimulateWithCounters(int numOfSteps)
        {
            while (numOfSteps > 0)
            {

                BigInteger[] nextGenerationCounters = new BigInteger[MaxFishTimerValue];

                if (_fishPopulationCounters[0] > 0) //Create new generation
                {
                    //Add the newborns
                    nextGenerationCounters[8] = _fishPopulationCounters[0];
                    nextGenerationCounters[6] = _fishPopulationCounters[0];
                }

                for (int i= 8; i>0; i--)
                {
                    nextGenerationCounters[i-1] += _fishPopulationCounters[i];
                }
                _fishPopulationCounters = nextGenerationCounters;

                numOfSteps--;
            }
        }

        public int GetPopulationSize()
        {
            return _fishPopulation.Count;
        }

        public BigInteger GetPopulationSizeByCounters()
        {
            BigInteger totalFishCount = 0;

            for (int i=0; i<9; i++)
            {
                totalFishCount += _fishPopulationCounters[i];
            }

            return totalFishCount;
        }
    }
}
