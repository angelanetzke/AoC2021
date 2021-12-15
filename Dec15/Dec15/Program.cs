using System;
using System.Collections.Generic;
using System.IO;

namespace Dec15
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			List<List<int>> costs = new();
			foreach (string thisLine in allLines)
			{
				List<int> row = new List<int>();
				foreach (char thisChar in thisLine)
				{
					row.Add(int.Parse(thisChar.ToString()));
				}
				costs.Add(row);
			}			
			Grid theGrid = new();
			int width = costs[0].Count;
			int height = costs.Count;
			for (int y = 0; y < costs.Count; y++)
			{
				for (int x = 0; x < costs[y].Count; x++)
				{
					theGrid.AddNode(x, y, width, height, costs[y][x]);
				}
			}
			Console.WriteLine($"part 1: {theGrid.GetShortestPath()}"); 
		}



	}
}
