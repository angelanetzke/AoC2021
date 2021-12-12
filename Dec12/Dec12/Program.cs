﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Dec12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			Dictionary<string, Cave> caves = new();
			Cave start = null;
			Cave end = null;
			foreach (string thisLine in allLines)
			{
				string firstID = thisLine.Split("-")[0];
				string secondID = thisLine.Split("-")[1];
				if (caves.TryGetValue(firstID, out Cave firstCave))
				{
					firstCave.Connect(secondID);
				}
				else
				{
					firstCave = new Cave(firstID, caves);
					caves[firstID] = firstCave;
					firstCave.Connect(secondID);
				}
				if (caves.TryGetValue(secondID, out Cave secondCave))
				{
					secondCave.Connect(firstID);
				}
				else
				{
					secondCave = new Cave(secondID, caves);
					caves[secondID] = secondCave;
					secondCave.Connect(firstID);
				}
				if (start == null && firstID == "start")
				{
					start = firstCave;
				}
				if (start == null && secondID == "start")
				{
					start = secondCave;
				}
				if (end == null && firstID == "end")
				{
					end = firstCave;
				}
				if (end == null && secondID == "end")
				{
					end = secondCave;
				}
			}
			List<Route> routesToEnd = start.Traverse(new Route(), end);
			Console.WriteLine($"part 1: {routesToEnd.Count}");
			

		}
	}
}
