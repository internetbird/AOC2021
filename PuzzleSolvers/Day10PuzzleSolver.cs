using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.PuzzleSolvers
{
    public class Day10PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day10.txt");

            int totalScore = 0;

            foreach (string line in inputLines)
            {
                int score = GetSyntaxErrorScore(line);
                totalScore += score;

            }
            return totalScore.ToString();
        }

        private int GetSyntaxErrorScore(string line)
        {
            var charStack = new Stack<char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (IsOpenBraket(line[i]))
                {
                    charStack.Push(line[i]);

                } else //closing braket
                {
                    char openingBraket = charStack.Pop();

                    if (!IsMatchingBrakets(openingBraket, line[i]))
                    {
                        int syntaxErrorScore = GetScoreForClosingBraket(line[i]);
                        return syntaxErrorScore;
                    }
                }
            }
            return 0;
        }

        private int GetScoreForClosingBraket(char closingBraket)
        {
            int score = 0;
          
            switch (closingBraket) {
                case ')':
                    score = 3;
                    break;
                case ']':
                    score = 57;
                    break;
                case '}':
                    score = 1197;
                    break;
                case '>':
                    score = 25137;
                    break;
            }
            return score;
        }

        private bool IsMatchingBrakets(char openingBraket, char closingBraket)
        {
            return (openingBraket == '(' && closingBraket == ')')
                   || (openingBraket == '{' && closingBraket == '}')
                   || (openingBraket == '[' && closingBraket == ']')
                   || (openingBraket == '<' && closingBraket == '>');
        }

        private bool IsOpenBraket(char letter)
        {
            return letter == '(' || letter == '{' || letter == '[' || letter == '<';
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day10.txt");

            var completionScores = new List<ulong>();

            foreach (string line in inputLines)
            {
                int score = GetSyntaxErrorScore(line);

                if (score == 0) //Line is incomplete
                {
                    string completionString = GetCompletionString(line);
                    ulong completionScore =  GetScoreForCompletionString(completionString);
                    completionScores.Add(completionScore);
                }
            }
            completionScores.Sort();

            return completionScores[(completionScores.Count - 1)/2].ToString();

        }

        private ulong GetScoreForCompletionString(string completionString)
        {
            ulong score = 0;

            for (int i = 0; i < completionString.Length; i++)
            {
                score = score * 5;
                score += GetScoreForCompletionClosingBraket(completionString[i]);
            }

            return score;
        }

        private ulong GetScoreForCompletionClosingBraket(char closingBraket)
        {
            switch (closingBraket)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;
            }

            return 0;
        }

        private string GetCompletionString(string line)
        {
            var charStack = new Stack<char>();

            var completionString = string.Empty;

            for (int i = 0; i < line.Length; i++)
            {
                if (IsOpenBraket(line[i]))
                {
                    charStack.Push(line[i]);

                }
                else //closing braket
                {
                   charStack.Pop();
                }
            }

            while(charStack.Any())
            {
               char popedBraket =  charStack.Pop();

                if (IsOpenBraket(popedBraket)) 
                {
                    completionString += GetMatchingClosingBraket(popedBraket);
                }
            }

            return completionString;
            
        }

        private char GetMatchingClosingBraket(char popedBraket)
        {
            switch (popedBraket)
            {
                case '(':
                    return ')';
                case '[':
                    return ']';
                case '{':
                    return '}';
                case '<':
                    return '>';
            }

            return char.MinValue;
        }
    }
}
