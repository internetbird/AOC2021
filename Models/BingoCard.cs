using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class BingoCard
    {
        private int[,] _nums = new int[5, 5];
        private bool[,] _markedMap = new bool[5, 5];

        public BingoCard(int[,] values)
        {
            _nums = values;
        }

        public int GetSumOfNonMarkedValues()
        {
            int sumOfNonMarkedValues = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!_markedMap[i, j])
                    {
                        sumOfNonMarkedValues += _nums[i, j];
                    }
                }
            };

            return sumOfNonMarkedValues;
        }

        public void MarkNum(int numCalled)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_nums[i, j] == numCalled)
                    {
                        _markedMap[i, j] = true;
                    }
                }
            }
        }

        public bool IsWinner()
        {
            return HasWinningRow() || HasWinningColumn();
        }

        private bool HasWinningColumn()
        {
            for(int i = 0; i < 5; i++)
            {
                if (_markedMap.GetColumn(i).All(marked => marked))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasWinningRow()
        {
            for (int i = 0; i < 5; i++)
            {
                if (_markedMap.GetRow(i).All(marked => marked))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
