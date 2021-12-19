using System.Collections.Generic;

namespace Dec19
{
	internal class Beacon
	{
		private readonly int x;
		private readonly int y;
		private readonly int z;
		private readonly HashSet<Distance> distances;

		public Beacon(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			distances = new();
		}

		public int GetX()
		{
			return x;
		}

		public int GetY()
		{
			return y;
		}

		public int GetZ()
		{
			return z;
		}

		public void AddDistance(Beacon other)
		{
			distances.Add(new Distance(this, other));
		}

		public void AddDistance(Distance newDistance)
		{
			distances.Add(newDistance);
		}

		public int CountDistanceMatches(Beacon other)
		{
			int count = 0;
			foreach (Distance thisDistance in distances)
			{
				if (other.distances.Contains(thisDistance))
				{
					count++;
				}
			}
			return count;
		}

		public override string ToString()
		{
			return "(" + x +"," + y + "," + z + ")";
		}
	}


}
