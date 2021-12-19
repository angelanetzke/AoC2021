using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec19
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Scanner> allScanners = new();
			Scanner current = null;
			string[] allLines = File.ReadAllLines("input.txt");
			foreach (string thisLine in allLines)
			{
				if (thisLine.StartsWith("--- scanner"))
				{
					current = new();
					allScanners.Add(current);
				}
				else if (current != null && thisLine.Length > 0)
				{
					current.AddBeacon(thisLine);
				}
			}
			foreach (Scanner thisScanner in allScanners)
			{
				thisScanner.CalculateDistances();
			}
			int beaconCount = allScanners.Sum(element => element.GetBeaconCount());
			for (int i = 0; i < allScanners.Count - 1; i++)
			{
				for (int j = i + 1; j < allScanners.Count; j++)
				{
					int scannerMatchCount = allScanners[i].CountMatchingBeacons(allScanners[j]);
					if (scannerMatchCount >= 12)
					{
						beaconCount -= scannerMatchCount;
					}
				}
			}
			Console.WriteLine($"part 1: {beaconCount}");
		}



	}
}
