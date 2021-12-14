using System.Collections.Generic;
using System.Linq;

namespace Dec14
{
	internal class Polymer
	{
		private readonly Dictionary<string, char> rules;
		private Dictionary<string, int> pairCount;
		private Dictionary<char, int> elementCount;
		public Polymer(string template)
		{
			rules = new();
			pairCount = new();
			for (int i = 0; i < template.Length - 1; i++)
			{
				string thisNewKey = template.Substring(i, 2);
				if (pairCount.TryGetValue(thisNewKey, out int count))
				{
					pairCount[thisNewKey] = count + 1;
				}
				else
				{
					pairCount[thisNewKey] = 1;
				}
			}
			elementCount = new();
			foreach (char thisChar in template)
			{
				if (elementCount.TryGetValue(thisChar, out int count))
				{
					elementCount[thisChar] = count + 1;
				}
				else
				{
					elementCount[thisChar] = 1;
				}
			}
		}

		public void AddRule(string ruleString)
		{
			string pair = ruleString.Split(" -> ")[0];
			char middleChar = ruleString.Split(" -> ")[1][0];
			rules.Add(pair, middleChar);
		}

		public void Execute(int times)
		{
			for (int iteration = 1; iteration <= times; iteration++)
			{
				int newCharCount = 0;
				Dictionary<string, int> newPairCount = new();
				foreach (string thisKey in pairCount.Keys)
				{
					newCharCount += pairCount[thisKey];
					char thisMiddleChar = rules[thisKey];
					if (elementCount.TryGetValue(thisMiddleChar, out int count))
					{
						elementCount[thisMiddleChar] = count + pairCount[thisKey];
					}
					else
					{
						elementCount[thisMiddleChar] = pairCount[thisKey];
					}
					string firstNewKey = thisKey[0] + thisMiddleChar.ToString();
					string secondNewKey = thisMiddleChar.ToString() + thisKey[1];
					if (newPairCount.TryGetValue(firstNewKey, out int firstCount))
					{
						newPairCount[firstNewKey] = firstCount + pairCount[thisKey];
					}
					else
					{
						newPairCount[firstNewKey] = pairCount[thisKey];
					}
					if (newPairCount.TryGetValue(secondNewKey, out int secondCount))
					{
						newPairCount[secondNewKey] = secondCount + pairCount[thisKey];
					}
					else
					{
						newPairCount[secondNewKey] = pairCount[thisKey];
					}
				}
				pairCount = newPairCount;
			}
		}

		public int GetPart1Answer()
		{
			return elementCount.Values.Max() - elementCount.Values.Min();

		}


	}
}
