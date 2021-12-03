using System;
using System.Collections.Generic;
using System.IO;

namespace Dec03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");
            int stringLength = allLines[0].Length;
            int[] oneCount = new int[stringLength];
            int[] zeroCount = new int[stringLength];
            for (int i = 0; i < allLines.Length; i++)
            {
                char[] characters = allLines[i].ToCharArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    if (characters[j] == '1')
                    {
                        oneCount[j]++;
                    }
                    else
                    {
                        zeroCount[j]++;
                    }
                }
            }
            char[] gammaArray = new char[stringLength];
            char[] epsilonArray = new char[stringLength];
            for (int i = 0; i < stringLength; i++)
            {
                if (oneCount[i] > zeroCount[i])
                {
                    gammaArray[i] = '1';
                    epsilonArray[i] = '0';
                }
                else
                {
                    gammaArray[i] = '0';
                    epsilonArray[i] = '1';
                }
            }
            int gammaRate = Convert.ToInt32(new String(gammaArray), 2);
            int epsilonRate = Convert.ToInt32(new String(epsilonArray), 2);
            long powerConsumption = (long)gammaRate * (long)epsilonRate;
            Console.WriteLine($"part 1: {powerConsumption}");

            // Part 2
            List<String> remainingOxygenStrings = new List<String>();
            remainingOxygenStrings.AddRange(allLines);
            List<String> remainingCO2Strings = new List<String>();
            remainingCO2Strings.AddRange(allLines);
            for (int i = 0; i < stringLength; i++)
            {
                if (remainingOxygenStrings.Count > 1)
                {
                    int oxygenOneCount = 0;
                    int oxygenZeroCount = 0;
                    foreach (string thisString in remainingOxygenStrings)
                    {
                        if (thisString.ToCharArray()[i] == '1')
                        {
                            oxygenOneCount++;
                        }
                        else
                        {
                            oxygenZeroCount++;
                        }
                    }
                    List<String> oxygenTemp = new List<String>();
                    char oxygenMostCommon = '1';
                    if (oxygenZeroCount > oxygenOneCount)
                    {
                        oxygenMostCommon = '0';
                    }

                    foreach (string thisString in remainingOxygenStrings)
                    {
                        if (thisString.ToCharArray()[i] == oxygenMostCommon)
                        {
                            oxygenTemp.Add(thisString);
                        }
                    }
                    remainingOxygenStrings = oxygenTemp;
                }
                if (remainingCO2Strings.Count > 1)
                {
                    int co2OneCount = 0;
                    int co2ZeroCount = 0;
                    foreach (string thisString in remainingCO2Strings)
                    {
                        if (thisString.ToCharArray()[i] == '1')
                        {
                            co2OneCount++;
                        }
                        else
                        {
                            co2ZeroCount++;
                        }
                    }
                    char co2MostCommon = '1';
                    if (co2ZeroCount > co2OneCount)
                    {
                        co2MostCommon = '0';
                    }
                    List<String> co2Temp = new List<String>();
                    foreach (string thisString in remainingCO2Strings)
                    {
                        if (thisString.ToCharArray()[i] != co2MostCommon)
                        {
                            co2Temp.Add(thisString);
                        }
                    }
                    remainingCO2Strings = co2Temp;
                }
                if (remainingOxygenStrings.Count == 1 && remainingCO2Strings.Count == 1)
                {
                    break;
                }
            }
            int oxygenGeneratorRating = Convert.ToInt32(remainingOxygenStrings[0], 2);
            int co2ScrubberRating = Convert.ToInt32(remainingCO2Strings[0], 2);
            long lifeSupportRating = (long)oxygenGeneratorRating * (long)co2ScrubberRating;
            Console.WriteLine($"part 2: {lifeSupportRating}");
        }
    }
}
