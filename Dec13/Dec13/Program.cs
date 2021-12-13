using System;
using System.Collections.Generic;
using System.IO;

namespace Dec13
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			List<string> dotLines = new();
			List<string> foldLines = new();
			bool areDotsComplete = false;
			foreach (string thisLine in allLines)
			{
				if (thisLine.Length == 0)
				{
					areDotsComplete = true;
				}
				else if (areDotsComplete)
				{
					foldLines.Add(thisLine);
				}
				else
				{
					dotLines.Add(thisLine);
				}
			}
			Transparency theTransparency = new();
			foreach (string thisDotString in dotLines)
			{
				theTransparency.AddDot(thisDotString);
			}
			theTransparency.FoldLeft(655);
			Console.WriteLine($"part 1: {theTransparency.CountDots()}");
		}




	}
}
