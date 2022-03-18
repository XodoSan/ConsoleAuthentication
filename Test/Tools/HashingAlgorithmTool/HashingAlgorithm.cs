using System.Collections.Generic;
using System.Linq;

namespace UserAuthorization.Tools.HashingAlghoritmTool
{
    public class HashingAlgorithm : IHashingAlgorithm
    {
        int temp;

        public string GetHash(List<char> charArray)
        {
            char[] myStr = Sault(charArray);

            for (int i = 0; i < myStr.Length; i++)
            {
                if (i != myStr.Length - 1) myStr[i] += myStr[i + 1];
                if (i != 0 && i != myStr.Length) myStr[i] += myStr[i - 1];
                myStr[i] = (char)Filter(myStr[i]);
            }

            temp = 0;
            return new string(myStr);
        }

        private int Filter(int x)
        {
            while (true)
            {
                if (x < 35) x = (x * x % 19) + 35;
                else if (x > 126) x = x & 126;
                else return x;
            }
        }

        private char[] Sault(List<char> charArray)
        {
            for (int i = 0; i < charArray.Count(); i++)
            {
                if (charArray.Count() > 36)
                {
                    temp += charArray[i] + charArray[i + 1];
                    charArray[i] = (char)temp;
                    charArray.Remove(charArray[i + 1]);
                }
                else if (charArray.Count() == 36)
                {
                    return charArray.ToArray();
                }
                else
                {
                    if (i + 1 < charArray.Count())
                    {
                        temp += charArray[i] + charArray[i + 1];
                        charArray[i] = (char)temp;
                    }
                    else
                    {
                        temp += charArray[i] + charArray[i - 1];
                        charArray.Add((char)temp);
                    }
                }
            }

            return charArray.ToArray();
        }
    }
}
