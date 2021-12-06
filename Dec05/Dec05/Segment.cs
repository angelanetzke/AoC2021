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

		public bool IsDiagonal()
		{
			return x1 != x2 && y1 != y2;
		}

		public int GetSlope()
		{
			if (IsDiagonal())
			{
				int leftX = Math.Min(x1, x2);
				int leftY;
				int rightX;
				int rightY;
				if (leftX == x1)
				{
					leftY = y1;
					rightX = x2;
					rightY = y2;
				}
				else
				{
					leftY = y2;
					rightX = x1;
					rightY = y1;
				}
				return Math.Sign((rightY - leftY) / (rightX - leftX));
			}
			return 0;
		}

		public bool IsLeftOf(Segment other)
		{
			int left1 = Math.Min(x1, x2);
			int left2 = Math.Min(other.x1, other.x2);
			return left1 <= left2;
		}

		public Point GetLeftPoint()
		{
			if (x1 < x2)
			{
				return new Point(x1, y1);
			}
			else
			{
				return new Point(x2, y2);
			}
		}

		public Point GetRightPoint()
		{
			if (x1 > x2)
			{
				return new Point(x1, y1);
			}
			else
			{
				return new Point(x2, y2);
			}
		}

		public Point GetTopPoint()
		{
			if (y1 < y2)
			{
				return new Point(x1, y1);
			}
			else
			{
				return new Point(x2, y2);
			}
		}

		public Point GetBottomPoint()
		{
			if (y1 > y2)
			{
				return new Point(x1, y1);
			}
			else
			{
				return new Point(x2, y2);
			}
		}

		public bool IsOnSegment(Point p)
		{
			if (IsVertical())
			{
				if (p.GetX() == x1 && Math.Min(y1, y2) <= p.GetY() && p.GetY() <= Math.Max(y1, y2))
				{
					return true;
				}
			}
			else if (IsHorizontal())
			{
				if (p.GetY() == y1 && Math.Min(x1, x2) <= p.GetX() && p.GetX() <= Math.Max(x1, x2))
				{
					return true;
				}
			}
			else if (IsDiagonal())
			{
				Point left = GetLeftPoint();
				Point right = GetRightPoint();
				Point top = GetTopPoint();
				Point bottom = GetBottomPoint();
				if (left.GetX() <= p.GetX() && p.GetX() <= right.GetX()
					&& top.GetY() <= p.GetY() && p.GetY() <= bottom.GetY()
					&& Math.Abs(p.GetX() - left.GetX()) == Math.Abs(p.GetY() - left.GetY()))
				{
					return true;
				}
			}
			return false;
		}

		public List<Point> GetOverlap(Segment other, bool isPart1)
		{
			List<Point> result = new List<Point>(); ;
			if (this.Equals(other))
			{
				return result;
			}
			else if (IsHorizontal() && other.IsHorizontal())
			{
				result = HorizontalHorizontal(other);
			}
			else if (IsVertical() && other.IsVertical())
			{
				result = VerticalVertical(other);
			}
			else if (IsHorizontal() && other.IsVertical())
			{
				result = HorizontalVertical(other);
			}
			else if (IsVertical() && other.IsHorizontal())
			{
				result = other.HorizontalVertical(this);
			}
			else if (!isPart1 && IsDiagonal() && other.IsDiagonal() && GetSlope() == other.GetSlope())
			{
				result = DiagonalSameSlope(other);
			}
			else if (!isPart1 && IsDiagonal() && other.IsDiagonal() && GetSlope() != other.GetSlope())
			{
				result = DiagonalDifferentSlope(other);
			}
			else if (!isPart1 && IsDiagonal() && other.IsVertical())
			{
				result = DiagonalVertical(other);
			}
			else if (!isPart1 && IsVertical() && other.IsDiagonal())
			{
				result = other.DiagonalVertical(this);
			}
			else if (!isPart1 && IsDiagonal() && other.IsHorizontal())
			{
				result = DiagonalHorizontal(other);
			}
			else if (!isPart1 && IsHorizontal() && other.IsDiagonal())
			{
				result = other.DiagonalHorizontal(this);
			}
			return result;
		}

		private List<Point> HorizontalHorizontal(Segment other)
		{
			List<Point> result = new List<Point>();
			if (y1 == other.y1)
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
			return result;
		}

		private List<Point> VerticalVertical(Segment other)
		{
			List<Point> result = new List<Point>();
			if (x1 == other.x1)
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
			return result;
		}

		private List<Point> HorizontalVertical(Segment other)
		{
			List<Point> result = new List<Point>();
			int left = Math.Min(x1, x2);
			int right = Math.Max(x1, x2);
			int top = Math.Min(other.y1, other.y2);
			int bottom = Math.Max(other.y1, other.y2);
			if (left <= other.x1 && other.x1 <= right && top <= y1 && y1 <= bottom)
			{
				result.Add(new Point(other.x1, y1));
			}
			return result;
		}

		private List<Point> DiagonalSameSlope(Segment other)
		{
			List<Point> result = new List<Point>();
			Segment leftSegment;
			Segment rightSegment;
			if (IsLeftOf(other))
			{
				leftSegment = this;
				rightSegment = other;
			}
			else
			{
				leftSegment = other;
				rightSegment = this;
			}
			int deltaXFull = rightSegment.GetRightPoint().GetX() - leftSegment.GetLeftPoint().GetX();
			int deltaYFull = rightSegment.GetRightPoint().GetY() - leftSegment.GetLeftPoint().GetY();
			if (Math.Abs(deltaXFull) == Math.Abs(deltaYFull)
				&& rightSegment.GetLeftPoint().IsLeftOf(leftSegment.GetRightPoint()))
			{
				Point endPoint;
				if (leftSegment.GetRightPoint().IsLeftOf(rightSegment.GetRightPoint()))
				{
					endPoint = leftSegment.GetRightPoint();
				}
				else
				{
					endPoint = rightSegment.GetRightPoint();
				}
				Point thisPoint = rightSegment.GetLeftPoint();
				bool complete = false;
				while (!complete)
				{
					result.Add(thisPoint);
					if (thisPoint.Equals(endPoint))
					{
						complete = true;
					}
					else
					{
						thisPoint = thisPoint.NextPoint(Math.Sign(deltaXFull), Math.Sign(deltaYFull));
					}
				}
			}
			return result;
		}

		private List<Point> DiagonalDifferentSlope(Segment other)
		{
			List<Point> result = new List<Point>();
			Point thisPoint = other.GetLeftPoint();
			Point endPoint = other.GetRightPoint();
			int deltaX = Math.Sign(endPoint.GetX() - thisPoint.GetX());
			int deltaY = Math.Sign(endPoint.GetY() - thisPoint.GetY());
			bool complete = false;
			while (!complete)
			{
				if (IsOnSegment(thisPoint))
				{
					result.Add(thisPoint);
					complete = true;
				}
				if (thisPoint.Equals(endPoint))
				{
					complete = true;
				}
				else
				{
					thisPoint = thisPoint.NextPoint(deltaX, deltaY);
				}
			}
			return result;
		}

		private List<Point> DiagonalHorizontal(Segment other)
		{
			List<Point> result = new List<Point>();
			Point thisPoint = other.GetLeftPoint();
			Point endPoint = other.GetRightPoint();
			bool complete = false;
			while (!complete)
			{
				if (IsOnSegment(thisPoint))
				{
					result.Add(thisPoint);
					complete = true;
				}
				if (thisPoint.Equals(endPoint))
				{
					complete = true;
				}
				else
				{
					thisPoint = thisPoint.NextPoint(1, 0);
				}
			}
			return result;
		}

		private List<Point> DiagonalVertical(Segment other)
		{
			List<Point> result = new List<Point>();
			Point thisPoint = other.GetTopPoint();
			Point endPoint = other.GetBottomPoint();
			bool complete = false;
			while (!complete)
			{
				if (IsOnSegment(thisPoint))
				{
					result.Add(thisPoint);
					complete = true;
				}
				if (thisPoint.Equals(endPoint))
				{
					complete = true;
				}
				else
				{
					thisPoint = thisPoint.NextPoint(0, 1);
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

		public override string ToString()
		{
			return x1 + "," + y1 + " -> " + x2 + "," + y2;
		}
	}
}
