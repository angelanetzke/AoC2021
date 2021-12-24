using System;
using System.IO;

namespace Dec22
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string[] allLines = File.ReadAllLines("input.txt");
			Reactor theReactor = new();
			for (int i = 0; i <= 19; i++)
			{
				theReactor.Next(allLines[i]);
			}
			Console.WriteLine($"part 1: {theReactor.CountCubes()}");

		}



	}
}
