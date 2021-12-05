using System;

namespace Dec05
{
	internal class Point
	{
		private readonly int x;
		private readonly int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object obj)
		{
			return obj is Point point &&
						 x == point.x &&
						 y == point.y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(x, y);
		}
	}
}
