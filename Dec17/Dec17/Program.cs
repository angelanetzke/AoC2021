using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Dec17
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string inputString = File.ReadAllText("input.txt");
			var regexY = Regex.Match(inputString, @"y=(?<yvalues>-*\d+..-*\d+)");
			int depth = 0 - int.Parse(regexY.Groups["yvalues"].Value.Split("..")[0]);
			int maxHeight = (depth - 1) * depth / 2;
			Console.WriteLine($"part 1: {maxHeight}");



		}
	}
}
