using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec21
{
	internal class Game
	{
		private int nextRoll;
		private int player1Position;
		private int player2Position;
		int player1Score;
		int player2Score;
		private bool isPlayer1Turn;
		private int rollCount;

		public Game(int player1Position, int player2Position)
		{
			nextRoll = 1;
			this.player1Position = player1Position;
			this.player2Position = player2Position;
			player1Score = 0;
			player2Score = 0;
			isPlayer1Turn = true;
			rollCount = 0;
		}

		public void Next()
		{
			int thisRoll = nextRoll * 3 + 3;
			nextRoll += 3;
			if (isPlayer1Turn)
			{
				player1Position = (player1Position + thisRoll - 1) % 10 + 1;
				player1Score += player1Position;
			}
			else
			{
				player2Position = (player2Position + thisRoll - 1) % 10 + 1;
				player2Score += player2Position;
			}
			rollCount += 3;
			isPlayer1Turn = !isPlayer1Turn;
		}

		public int GetPlayer1Score()
		{
			return player1Score;
		}

		public int GetPlayer2Score()
		{
			return player2Score;
		}

		public int GetRollCount()
		{
			return rollCount;
		}


	}
}
