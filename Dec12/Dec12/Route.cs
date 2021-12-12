using System.Collections.Generic;

namespace Dec12
{
	internal class Route
	{
		private List<Cave> caves;

		public Route()
		{
			caves = new();
		}

		public Route Clone()
		{
			Route newPath = new();
			newPath.caves = new List<Cave>(caves);
			return newPath;
		}
		public void Add(Cave newCave)
		{
			caves.Add(newCave);
		}

		public bool Contains(Cave aCave)
		{
			return caves.Contains(aCave);
		}
	}
}
