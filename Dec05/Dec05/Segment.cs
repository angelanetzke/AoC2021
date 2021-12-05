using System;
using System.Collections.Generic;

namespace Dec05
{
	internal class Segment
	{
		private readonly int x1;
		private readonly int y1;
		private readonly int x2;
		private readonly int y2;

		public Segment(int x1, int y1, int x2, int y2)
		{
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
		}

		public bool IsHorizontal()
		{
			return y1 == y2;
		}

		public bool IsVertical()
		{
			return x1 == x2;
		}

		public List<Point> GetOverlap(Segment other)
		{
			List<Point> result = new List<Point>();
			if (this.Equals(other))
			{
				return result;
			}
			else if (IsHorizontal() && other.IsHorizontal() && y1 == other.y1)
			{
				int left1 = Math.Min(x1, x2);
				int right1 = Math.Max(x1, x2);
				int left2 = Math.Min(other.x1, other.x2);
				int right2 = Math.Max(other.x1, other.x2);
				int[] sorted = new int[] { left1, right1, left2, right2 };
				Array.Sort(sorted);
				if ((sorted[0] == left1 && sorted[1] == left2) || (sorted[0] == left2 && sorted[1] == left1))
				{
					int startX = sorted[1];
					int endX = sorted[2];
					for (int xValue = startX; xValue <= endX; xValue++)
					{
						result.Add(new Point(xValue, y1));
					}
				}
			}
			else if (IsVertical() && other.IsVertical() && x1 == other.x1)
			{
				int top1 = Math.Min(y1, y2);
				int bottom1 = Math.Max(y1, y2);
				int top2 = Math.Min(other.y1, other.y2);
				int bottom2 = Math.Max(other.y1, other.y2);
				int[] sorted = new int[] { top1, bottom1, top2, bottom2 };
				Array.Sort(sorted);
				if ((sorted[0] == top1 && sorted[1] == top2) || (sorted[0] == top2 && sorted[1] == top1))
				{
					int startY = sorted[1];
					int endY = sorted[2];
					for (int yValue = startY; yValue <= endY; yValue++)
					{
						result.Add(new Point(x1, yValue));
					}
				}
			}
			else if (IsVertical() && other.IsHorizontal())
			{
				int left = Math.Min(other.x1, other.x2);
				int right = Math.Max(other.x1, other.x2);
				int top = Math.Min(y1, y2);
				int bottom = Math.Max(y1, y2);
				if (left <= x1 && x1 <= right && top <= other.y1 && other.y1 <= bottom)
				{
					result.Add(new Point(x1, other.y1));
				}
			}
			else if (IsHorizontal() && other.IsVertical())
			{
				int left = Math.Min(x1, x2);
				int right = Math.Max(x1, x2);
				int top = Math.Min(other.y1, other.y2);
				int bottom = Math.Max(other.y1, other.y2);
				if (left <= other.x1 && other.x1 <= right && top <= y1 && y1 <= bottom)
				{
					result.Add(new Point(other.x1, y1));
				}
			}
			return result;
		}

		public override bool Equals(object obj)
		{
			if (obj is not Segment)
			{
				return false;
			}
			Segment other = (Segment)obj;
			if (x1 == other.x1 && y1 == other.y1 && x2 == other.x2 && y2 == other.y2)
			{
				return true;
			}
			if (x1 == other.x2 && y1 == other.y2 && x2 == other.x1 && y2 == other.y1)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(x1 + x2, y1 + y2);
		}
	}
}
