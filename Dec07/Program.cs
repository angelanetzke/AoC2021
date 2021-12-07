using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec07
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			int[] positions = Array.ConvertAll<string, int>(allLines[0].Split(","), element => int.Parse(element));
			Array.Sort(positions);
			int minPosition = positions[0];
			int maxPosition = positions[positions.Length - 1];
			Dictionary<int, int> moveCost = new() { };
			for (int newPosition = minPosition; newPosition <= maxPosition; newPosition++)
			{
				int thisNewPositionCost = 0;
				Array.ForEach<int>(positions, element => thisNewPositionCost += Math.Abs(element - newPosition));
				moveCost[newPosition] = thisNewPositionCost;
			}
			Console.WriteLine($"part 1: {moveCost.Values.Min()}");

		}
	}
}
