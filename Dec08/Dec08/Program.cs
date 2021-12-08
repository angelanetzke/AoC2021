using System;
using System.IO;
using System.Linq;

namespace Dec08
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			int part1Count = 0;
			foreach (string thisLine in allLines)
			{
				string[] outputs = thisLine.Split(" | ")[1].Split(" ");
				part1Count += outputs.Count(element => element.Length == 2);
				part1Count += outputs.Count(element => element.Length == 4);
				part1Count += outputs.Count(element => element.Length == 3);
				part1Count += outputs.Count(element => element.Length == 7);
			}
			Console.WriteLine($"part 1: {part1Count}");
		}
	}
}
