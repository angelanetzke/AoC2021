﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dec13
{
	internal class Transparency
	{
		private HashSet<Location> dots;

		public Transparency()
		{
			dots = new();
		}

		public void AddDot(string dotString)
		{
			int thisX = int.Parse(dotString.Split(",")[0]);
			int thisY = int.Parse(dotString.Split(",")[1]);
			dots.Add(new Location(thisX, thisY));
		}

		public int CountDots()
		{
			return dots.Count;
		}

		public void FoldUp(int foldY)
		{
			HashSet<Location> newDots = new();
			foreach (Location thisLocation in dots)
			{
				int thisX = thisLocation.GetX();
				int thisY = thisLocation.GetY();
				int newY;
				if (thisY > foldY)
				{
					newY = foldY - (thisY - foldY);
				}
				else
				{
					newY = thisY;
				}
				newDots.Add(new Location(thisX, newY));
			}
			dots = newDots;
		}

		public void FoldLeft(int foldX)
		{
			HashSet<Location> newDots = new();
			foreach (Location thisLocation in dots)
			{
				int thisX = thisLocation.GetX();
				int thisY = thisLocation.GetY();
				int newX;
				if (thisX > foldX)
				{
					newX = foldX - (thisX - foldX);
				}
				else
				{
					newX = thisX;
				}
				newDots.Add(new Location(newX, thisY));
			}
			dots = newDots;
		}

		public override string ToString()
		{
			StringBuilder builder = new();
			int maxX = dots.Max<Location>(element => element.GetX());
			int maxY = dots.Max<Location>(element => element.GetY());
			for (int y = 0; y <= maxY; y++)
			{
				for (int x = 0; x <= maxX; x++)
				{
					if (dots.Contains(new Location(x, y)))
					{
						builder.Append('#');
					}
					else
					{
						builder.Append(' ');
					}
				}
				builder.Append('\n');
			}
			return builder.ToString();
		}

	}
}