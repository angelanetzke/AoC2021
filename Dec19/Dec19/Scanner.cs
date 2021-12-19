using System.Collections.Generic;

namespace Dec19
{
	internal class Scanner
	{
		private readonly List<Beacon> beaconList;

		public Scanner()
		{
			beaconList = new();
		}

		public void AddBeacon(string coordinatesString)
		{
			string[] coordinatesArray = coordinatesString.Split(",");
			int x = int.Parse(coordinatesArray[0]);
			int y = int.Parse(coordinatesArray[1]);
			int z = int.Parse(coordinatesArray[2]);
			beaconList.Add(new Beacon(x, y, z));
		}

		public void CalculateDistances()
		{
			for (int i = 0; i < beaconList.Count; i++)
			{
				for (int j = 0; j < beaconList.Count; j++)
				{
					if (i != j)
					{
						beaconList[i].AddDistance(beaconList[j]);
					}
				}
			}
		}

		public int CountMatchingBeacons(Scanner other)
		{
			int count = 0;
			foreach (Beacon beacon1 in beaconList)
			{
				foreach (Beacon beacon2 in other.beaconList)
				{
					if (beacon1.CountDistanceMatches(beacon2) >= 11)
					{
						count++;
					}
				}
			}
			return count;
		}

		public int GetBeaconCount()
		{
			return beaconList.Count;
		}

	}


}
