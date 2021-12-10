using System;
using System.Collections.Generic;
using System.IO;

namespace Dec10
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			int part1Score = 0;
			foreach (string thisLine in allLines)
			{
				part1Score += (new Line(thisLine).GetPart1Score());
			}
			Console.WriteLine($"part 1: {part1Score}");

			// Part 2
			List<long> part2Scores = new();
			foreach (string thisLine in allLines)
			{
				Line thisSubsystemLine = new(thisLine);
				if (thisSubsystemLine.GetPart1Score() == 0)
				{
					part2Scores.Add((new Line(thisLine).GetPart2Score()));
				}
			}
			part2Scores.Sort();
			Console.WriteLine($"part 2: {part2Scores[part2Scores.Count / 2]}");
		}
	}
}
