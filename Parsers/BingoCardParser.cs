using AOC2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Parsers
{
    public class BingoCardParser
    {
        public BingoCard ParseInput(string[] inputLines)
        {
            int[,] cardValues = new int[5, 5];

            for (int i = 1; i < inputLines.Length; i++)
            {
                int[] rowValues = inputLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(value => int.Parse(value)).ToArray();

                for (int j = 0; j < 5; j++)
                {
                    cardValues[i-1, j] = rowValues[j];
                }
            }

            var card = new BingoCard(cardValues);
            return card;

        }
    }
}
