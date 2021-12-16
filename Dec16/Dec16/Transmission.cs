using System;
using System.Text;

namespace Dec16
{
	internal class Transmission
	{
		private readonly string binaryString;
		private int index;
		public Transmission(string hexString)
		{
			index = 0;
			StringBuilder builder = new();
			foreach (char thisChar in hexString)
			{
				switch(thisChar)
				{
					case '0':
						builder.Append("0000");
						break;
					case '1':
						builder.Append("0001");
						break;
					case '2':
						builder.Append("0010");
						break;
					case '3':
						builder.Append("0011");
						break;
					case '4':
						builder.Append("0100");
						break;
					case '5':
						builder.Append("0101");
						break;
					case '6':
						builder.Append("0110");
						break;
					case '7':
						builder.Append("0111");
						break;
					case '8':
						builder.Append("1000");
						break;
					case '9':
						builder.Append("1001");
						break;
					case 'A':
						builder.Append("1010");
						break;
					case 'B':
						builder.Append("1011");
						break;
					case 'C':
						builder.Append("1100");
						break;
					case 'D':
						builder.Append("1101");
						break;
					case 'E':
						builder.Append("1110");
						break;
					case 'F':
						builder.Append("1111");
						break;
				}
			}
			binaryString = builder.ToString();
		}

		public int GetVersionNumberSum()
		{
			index = 0;
			int sum = 0;
			while (binaryString.Substring(index).Contains('1'))
			{
				sum += GetSubPacketVersionNumber();
				
			}
			return sum;
		}

		private int GetSubPacketVersionNumber()
		{
			int sum = 0;
			int versionNumber = Convert.ToInt32(GetNextSubstring(3), 2);
			sum += versionNumber;
			int typeID = Convert.ToInt32(GetNextSubstring(3) ,2);
			if (typeID == 4)
			{
				string groupString;
				do
				{
					groupString = GetNextSubstring(5);
				} while (groupString.StartsWith('1'));
			}
			else
			{
				int lengthType = Convert.ToInt32(GetNextSubstring(1), 2);
				if (lengthType == 0)
				{
					int subpacketLength = Convert.ToInt32(GetNextSubstring(15), 2);
					int endIndex = index + subpacketLength;
					while (index < endIndex)
					{
						sum += GetSubPacketVersionNumber();
					}
				}
				else
				{
					int subpacketCount = Convert.ToInt32(GetNextSubstring(11), 2);
					for (int i = 1; i <= subpacketCount; i++)
					{
						sum += GetSubPacketVersionNumber();
					}
				}
			}
			return sum;
		}

		private string GetNextSubstring(int length)
		{
			string nextString = binaryString.Substring(index, length);
			index += length;
			return nextString;
		}





	}
}
