using System;
using System.Collections.Generic;
using System.IO;

namespace Dec05
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			List<Segment> allSegments = new List<Segment>();
			foreach (string thisLine in allLines)
			{
				int x1 = int.Parse(thisLine.Split(" -> ")[0].Split(",")[0]);
				int y1 = int.Parse(thisLine.Split(" -> ")[0].Split(",")[1]);
				int x2 = int.Parse(thisLine.Split(" -> ")[1].Split(",")[0]);
				int y2 = int.Parse(thisLine.Split(" -> ")[1].Split(",")[1]);
				allSegments.Add(new Segment(x1, y1, x2, y2));
			}
			HashSet<Point> overlappingPoints = new HashSet<Point>();
			for (int i = 0; i < allSegments.Count - 1; i++)
			{
				for (int j = i + 1; j < allSegments.Count; j++)
				{
					List<Point> thisPointList = allSegments[i].GetOverlap(allSegments[j]);
					foreach (Point thisPoint in thisPointList)
					{
						overlappingPoints.Add(thisPoint);
					}
				}
			}
			Console.WriteLine($"part 1: {overlappingPoints.Count}");
		}
	}
}
