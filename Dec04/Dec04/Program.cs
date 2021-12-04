using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Dec04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");
            string[] numbers = allLines[0].Split(',');
            const int SIZE = 5;
            int startIndex = 2;
            List<BingoCard> cards = new List<BingoCard>();
            while (startIndex + SIZE < allLines.Length)
            {
                BingoCard thisCard = new BingoCard();
                for (int i = startIndex; i <= startIndex + SIZE - 1; i++)
                {
                    thisCard.AddRow(allLines[i]);
                }
                cards.Add(thisCard);
                startIndex += SIZE + 1;
            }
            BingoCard winner = null;
            foreach (string thisNumber in numbers)
            {
                foreach(BingoCard thisCard in cards)
                {
                    thisCard.MarkSquare(int.Parse(thisNumber));
                }
                foreach (BingoCard thisCard in cards)
                {
                    if (thisCard.IsAWinner())
                    {
                        winner = thisCard;
                        break;
                    }
                }
                if (winner != null)
                {
                    break;
                }
            }
            if (winner != null)
            {
                long part1Answer = (long)winner.GetLastNumber() * winner.GetUnmarkedSum();
                Console.WriteLine($"part 1: {part1Answer}");
            }
            else
            {
                Console.WriteLine("try again");
            }
        }
    }
}
