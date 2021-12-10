using System;
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
				part1Score += (new Line(thisLine).GetScore());
			}
			Console.WriteLine($"part 1: {part1Score}");
		}
	}
}
