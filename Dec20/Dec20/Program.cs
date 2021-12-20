﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Dec20
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			string algorithm = allLines[0];
			List<string> initialImage = new();
			for (int i = 2; i < allLines.Length; i++)
			{
				initialImage.Add(allLines[i]);
			}
			Image theImage = new(algorithm, initialImage);
			theImage.Enhance();
			theImage.Enhance();
			Console.WriteLine($"part 1: {theImage.CountLights()}");
		}


	}
}
