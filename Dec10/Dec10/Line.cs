﻿using System.Collections.Generic;

namespace Dec10
{
	internal class Line
	{
		private string text;
		private static readonly List<char> leftCharacters = new() { '(', '[', '{', '<' };
		private static readonly List<char> rightCharacters = new() { ')', ']', '}', '>' };
		private static readonly Dictionary<char, char> partners = new()
		{
			['('] = ')',
			['['] = ']',
			['{'] = '}',
			['<'] = '>'
		};

		public Line(string text)
		{
			this.text = text;
		}

		public int GetPart1Score()
		{
			Stack<char> chars = new();
			foreach (char thisChar in text)
			{
				if (leftCharacters.Contains(thisChar))
				{
					chars.Push(thisChar);
				}
				else if (rightCharacters.Contains(thisChar))
				{
					char topChar = chars.Peek();
					if (partners[topChar] == thisChar)
					{
						chars.Pop();
					}
					else
					{
						switch (thisChar)
						{
							case ')':
								return 3;
							case ']':
								return 57;
							case '}':
								return 1197;
							case '>':
								return 25137;
						}
					}
				}
			}
			return 0;
		}

		public long GetPart2Score()
		{			
			Stack<char> chars = new();
			foreach (char thisChar in text)
			{
				if (leftCharacters.Contains(thisChar))
				{
					chars.Push(thisChar);
				}
				else if (rightCharacters.Contains(thisChar))
				{
					char topChar = chars.Peek();
					if (partners[topChar] == thisChar)
					{
						chars.Pop();
					}					
				}
			}
			long score = 0L;
			while(chars.Count > 0)
			{
				char topChar = chars.Pop();
				switch (topChar)
				{
					case '(':
						score = score * 5L + 1L;
						break;
					case '[':
						score = score * 5L + 2L;
						break;
					case '{':
						score = score * 5L + 3L;
						break;
					case '<':
						score = score * 5L + 4L;
						break;
				}
			}
			return score;
		}


	}
}