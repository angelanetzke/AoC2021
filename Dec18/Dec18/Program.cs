using System;
using System.IO;

namespace Dec18
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] allLines = File.ReadAllLines("input.txt");
			PairTree combinedTree = null;
			foreach (string thisLine in allLines)
			{
				if (combinedTree == null)
				{
					combinedTree = new PairTree(thisLine);
				}
				else
				{
					combinedTree = combinedTree.Add(new PairTree(thisLine));
				}
				bool didSplit;
				bool didExplode;
				do
				{
					didExplode = true;
					didSplit = true;
					int explodeCount = 0;
					while (combinedTree.Explode())
					{
						explodeCount++;
					}
					if (explodeCount == 0)
					{
						didExplode = false;
					}
					didSplit = combinedTree.Split();
				} while (didSplit || didExplode);
			}
			Console.WriteLine($"part 1: {combinedTree.GetMagnitude()}");

		}
	}
}
