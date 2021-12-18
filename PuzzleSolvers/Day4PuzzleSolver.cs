using AOC;
using AOC2021.Models;
using AOC2021.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day4PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
          
            (int[] gameValues, List<BingoCard> bingoCards) = GetBingoGameInputs();

            var game = new BingoGame(bingoCards, gameValues);

            (BingoCard winningCard, int lastNumCalled) = game.PlayGame();

            int sumOfNonMarkedValues = winningCard.GetSumOfNonMarkedValues();

            return (sumOfNonMarkedValues * lastNumCalled).ToString();
        }

        private (int[] gameValues, List<BingoCard> bingoCards)  GetBingoGameInputs()
        {
            int[] gameValues;
            List<BingoCard> bingoCards;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day4.txt");

            gameValues = inputLines[0].Split(',').Select(value => int.Parse(value)).ToArray();
            var parser = new BingoCardParser();

            bingoCards = new List<BingoCard>();
            for (int i = 1; i < inputLines.Length; i += 6)
            {
                string[] currCardLines = inputLines[i..(i + 6)];

                BingoCard card = parser.ParseInput(currCardLines);
                bingoCards.Add(card);
            }

            return (gameValues, bingoCards);
        }

        public string SolvePuzzlePart2()
        {
            (int[] gameValues, List<BingoCard> bingoCards) = GetBingoGameInputs();

            var game = new BingoGame(bingoCards, gameValues);

            (BingoCard lastWinningCard, int lastNumCalled) = game.PlayGameUntilLastCardWins();

            int sumOfNonMarkedValues = lastWinningCard.GetSumOfNonMarkedValues();

            return (sumOfNonMarkedValues * lastNumCalled).ToString();
        }

    }
}
