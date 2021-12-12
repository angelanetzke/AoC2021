using System;
using System.Collections.Generic;

namespace Dec12
{
	internal class Cave
	{
		private readonly string id;
		private readonly HashSet<string> adjacent;
		private readonly Dictionary<string, Cave> caveDictionary;
		private enum CaveType
		{
			LARGE,
			SMALL,
			SPECIAL
		}
		private readonly CaveType type;

		public Cave(string id, Dictionary<string, Cave> caveDictionary)
		{
			this.id = id;
			adjacent = new();
			this.caveDictionary = caveDictionary;
			if (id == "start" || id == "end")
			{
				type = CaveType.SPECIAL;
			}
			else if (id == id.ToUpper())
			{
				type = CaveType.LARGE;
			}
			else
			{
				type = CaveType.SMALL;
			}
		}

		public string GetID()
		{
			return id;
		}

		public void Connect(string other)
		{
			adjacent.Add(other);
		}

		public List<Route> Traverse(Route toHere, Cave end)
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
					if (nextCave.type == CaveType.SMALL && toHere.Contains(nextCave))
					{
						continue;
					}
					if (nextCave.id == "start")
					{
						continue;
					}
					List<Route> nextCaveRoutes = nextCave.Traverse(toHere.Clone(), end);
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
