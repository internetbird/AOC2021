using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class BingoGame
    {
        private List<BingoCard> _cards;
        private int[] _gameValues;

        public BingoGame(List<BingoCard> cards, int[] gameValues)
        {
            _cards = cards;
           _gameValues = gameValues;

        }

        /// <summary>
        /// Starts playing the game
        /// </summary>
        /// <returns>The winnning Bingo card and the last number called</returns>
        public (BingoCard winningCard, int lastNumberCalled) PlayGame()
        {

            bool hasWinner = false;
            int currValueIndex = 0;
            int lastNumCalled = _gameValues[0];
            BingoCard winningCard = null;

            while (!hasWinner)
            {
                lastNumCalled = _gameValues[currValueIndex];
                foreach (BingoCard card in _cards)
                {
                    card.MarkNum(lastNumCalled);

                    if (card.IsWinner())
                    {
                        hasWinner = true;
                        winningCard = card;
                        break;
                    }
                }
                currValueIndex++;   
            }

            return (winningCard, lastNumCalled);
        }


        public (BingoCard lastWinningCard, int lastNumberCalled) PlayGameUntilLastCardWins()
        {
            int currValueIndex = 0;
            int lastNumCalled = _gameValues[0];
            BingoCard lastWinningCard = null;

            while (_cards.Any())
            {
                lastNumCalled = _gameValues[currValueIndex];

                var winnerCards = new List<BingoCard>();   

                foreach (BingoCard card in _cards)
                {
                    card.MarkNum(lastNumCalled);

                    if (card.IsWinner())
                    {
                       winnerCards.Add(card);   
                    }
                }

                foreach (BingoCard winnerCard in winnerCards)
                {
                    lastWinningCard = winnerCard;
                    _cards.Remove(winnerCard);
                }

                currValueIndex++;
            }

            return (lastWinningCard, lastNumCalled);

        }
    }
}
