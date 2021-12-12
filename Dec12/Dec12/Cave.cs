using System;
using System.Collections.Generic;

namespace Dec12
{
	internal class Cave
	{
		private readonly string id;
		private readonly HashSet<string> adjacent;
		private readonly Dictionary<string, Cave> caveDictionary;
		public enum CaveType
		{
			LARGE,
			SMALL,
			SPECIAL
		}
		private readonly CaveType caveType;

		public Cave(string id, Dictionary<string, Cave> caveDictionary)
		{
			this.id = id;
			adjacent = new();
			this.caveDictionary = caveDictionary;
			if (id == "start" || id == "end")
			{
				caveType = CaveType.SPECIAL;
			}
			else if (id == id.ToUpper())
			{
				caveType = CaveType.LARGE;
			}
			else
			{
				caveType = CaveType.SMALL;
			}
		}

		public string GetID()
		{
			return id;
		}

		public CaveType GetCaveType()
		{
			return caveType;
		}

		public void Connect(string other)
		{
			adjacent.Add(other);
		}

		public List<Route> Traverse(Route toHere, Cave end, Cave smallDuplicate)
		{
			toHere.Add(this);
			if (this.Equals(end))
			{
				return new List<Route> { toHere };
			}
			else
			{
				List<Route> routes = new();
				foreach (string nextCaveId in adjacent)
				{
					Cave nextCave = caveDictionary[nextCaveId];
					int maxVisitedTimes;
					if (nextCave.caveType == CaveType.LARGE)
					{
						maxVisitedTimes = int.MaxValue;
					}
					else if (nextCave == smallDuplicate)
					{
						maxVisitedTimes = 2;
					}
					else
					{
						maxVisitedTimes = 1;
					}
					if (toHere.Count(nextCave) >= maxVisitedTimes)
					{
						continue;
					}
					List<Route> nextCaveRoutes = nextCave.Traverse(toHere.Clone(), end, smallDuplicate);
					if (nextCaveRoutes != null)
					{
						routes.AddRange(nextCaveRoutes);
					}					
				}
				if (routes.Count > 0)
				{
					return routes;
				}
				else
				{
					return null;
				}
			}
		}

		public override bool Equals(object obj)
		{
			return obj is Cave cave &&
						 id == cave.id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(id);
		}
	}
}
