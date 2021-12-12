using System;
using System.Collections.Generic;
using System.Linq;

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

		public int Count(Cave aCave)
		{
			return caves.Count(element => element.Equals(aCave));
		}

		public override bool Equals(object obj)
		{
			if (obj is not Route)
			{
				return false;
			}
			else
			{
				Route other = (Route)obj;
				if (caves.Count != other.caves.Count)
				{
					return false;
				}
				for (int i = 0; i < caves.Count; i++)
				{
					if (caves[i] != other.caves[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		public override int GetHashCode()
		{
			int hash = 17;
			foreach (Cave thisCave in caves)
			{
				hash = HashCode.Combine(hash, thisCave.GetHashCode());
			}
			return hash;
		}
	}
}
