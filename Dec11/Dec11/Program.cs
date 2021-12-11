using System;
using System.IO;

namespace Dec11
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			Grid theGrid = new();
			foreach (string thisLine in allLines)
			{
				theGrid.AddRow(thisLine);
			}
			int totalFlashes = 0;
			int STEPS = 100;
			for (int i = 0; i < STEPS; i++)
			{
				totalFlashes += theGrid.Update();
			}
			Console.WriteLine($"part 1: {totalFlashes}");
			
		}
	}
}
