using System.Collections.Generic;
using System.Linq;

namespace Dec09
{
	internal class HeightMap
	{
		private readonly List<List<int>> heights;

		public HeightMap()
		{
			heights = new();
		}

		public void AddRow(string row)
		{
			List<int> newHeightRow = new();
			foreach (char c in row)
			{
				newHeightRow.Add(int.Parse(c.ToString()));
			}
			heights.Add(newHeightRow);
		}

		public int GetTotalRiskLevel()
		{
			List<int> lowPoints = new();
			for (int row = 0; row < heights.Count; row++)
			{
				for (int column = 0; column < heights[0].Count; column++)
				{
					List<int> localArea = new();
					localArea.Add(heights[row][column]);
					if (row > 0)
					{
						localArea.Add(heights[row - 1][column]);
					}
					if (row < heights.Count - 1)
					{
						localArea.Add(heights[row + 1][column]);
					}
					if (column > 0)
					{
						localArea.Add(heights[row][column - 1]);
					}
					if (column < heights[row].Count - 1)
					{
						localArea.Add(heights[row][column + 1]);
					}
					if (heights[row][column] == localArea.Min() 
						&& localArea.Count(element => element == heights[row][column]) == 1)
					{
						lowPoints.Add(heights[row][column]);
					}
				}
			}
			int total = lowPoints.Sum() + lowPoints.Count;
			return total;
		}




	}

}
