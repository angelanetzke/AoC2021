using System;
using System.IO;

namespace Dec14
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			Polymer thePolymer = new(allLines[0]);
			for (int i = 2; i < allLines.Length; i++)
			{
				thePolymer.AddRule(allLines[i]);
			}
			thePolymer.Execute(10);
			Console.WriteLine($"part 1: {thePolymer.GetPart1Answer()}");
		}
	}
}
