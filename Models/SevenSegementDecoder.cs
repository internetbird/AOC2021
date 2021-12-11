using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Models
{
    public class SevenSegementDecoder
    {

        public int DecodeLine(string line)
        {

            string[] parts = line.Split('|');

            string[] signals = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] segments = parts[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < segments.Length; i++)
            {
                int segmentLength = segments[i].Length;

                if (segmentLength == 7)
                {
                    segments[i] = "8";

                }
                else if (segmentLength == 3)
                {
                    segments[i] = "7";
                }
                else if (segmentLength == 4)
                {
                    segments[i] = "4";

                }
                else if (segmentLength == 2)
                {
                    segments[i] = "1";

                }
                else if (segmentLength == 6) //6 or 9 or 0
                {
                    char[] digit1Signal = signals.First(signal => signal.Length == 2).ToCharArray();
                    char[] segmentChars = segments[i].ToCharArray();

                    if (!digit1Signal.Except(segmentChars).Any())
                    {
                        char[] digit4Signal = signals.First(signal => signal.Length == 4).ToCharArray();

                        if (digit4Signal.Except(segmentChars).Any())
                        {
                            segments[i] = "0";

                        } else
                        {
                            segments[i] = "9";
                        }
                       
                    } else
                    {
                        segments[i] = "6";
                    }

                }
                else if (segmentLength == 5) // 2 or 3 or 5
                {
                    char[] digit9Signal = GetDigit9Signal(signals); 
                   
                    if (segments[i].ToCharArray().Except(digit9Signal).Any())
                    {
                        segments[i] = "2";

                    } else // 3 or 5
                    {
                        char[] digit1Signal = signals.First(signal => signal.Length == 2).ToCharArray();

                        if (!digit1Signal.Except(segments[i].ToCharArray()).Any())
                        {
                            segments[i] = "3";
                        } else
                        {
                            segments[i] = "5";
                        }
                    }
                }
            }

            Console.WriteLine($"{line} | {string.Join(' ', segments)}");

            int result = int.Parse(string.Join(string.Empty ,segments));

            return result;
        }

        private char[] GetDigit9Signal(string[] signals)
        {
            char[] digit9Signal;

            char[] digit1Signal = signals.First(signal => signal.Length == 2).ToCharArray();

            string[] length6Signals = signals.Where(signal => signal.Length == 6).ToArray();
            char[] digit4Signal = signals.First(signal => signal.Length == 4).ToCharArray();

            string[] signals0and9 =  length6Signals.Where(signal => !digit1Signal.Except(signal).Any()).ToArray();
            if (digit4Signal.Except(signals0and9[0]).Any()){

                digit9Signal = signals0and9[1].ToCharArray();
            } else
            {
                digit9Signal = signals0and9[0].ToCharArray();
            }

            return digit9Signal;
        }


    }
}
