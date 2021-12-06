using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec06
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			List<long> fish = Enumerable.Repeat(0l, 9).ToList();
			string[] initialValues = allLines[0].Split(",");
			foreach (string thisValue in initialValues)
			{
				fish[int.Parse(thisValue)]++;
			}			
			const int TOTAL_DAYS = 80;
			for (int day = 0; day < TOTAL_DAYS; day++)
			{
				long zeroDayFish = fish[0];
				for (int i = 0; i < fish.Count - 1; i++)
				{
					fish[i] = fish[i + 1];
				}
				fish[6] += zeroDayFish;
				fish[8] = zeroDayFish;
			}
			Console.WriteLine($"part 1: {fish.Sum()}");

		}

	}
}
