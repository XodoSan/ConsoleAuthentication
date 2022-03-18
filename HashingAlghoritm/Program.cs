using System;
using System.Collections.Generic;
using System.Linq;

namespace HashingAlghoritm
{
    class Program
    {
        private int temp;

        static void Main(string[] args)
        {
            int collisionCounter = 0;

            Program program = new();
            WordGenerator wordGenerator = new();
            Test test = new();

            List<char> charArray;
            List<string> hashs = new();

            int iterations = 100000;

            for (int i = 0; i < iterations; i++)
            {
                charArray = wordGenerator.GenerateWord()
                    .ToCharArray()
                    .ToList();

                hashs.Add(program.Hashing(charArray));
            }

            collisionCounter = test.CollisionTest(hashs);

            Console.WriteLine($"Collisions: {collisionCounter}");
        }

        public int filter(int x)
        {
            while (true)
            {
                if (x < 35) x = (x * x % 19) + 35;
                else if (x > 126) x = x & 126;
                else return x;
            }
        }

        public string Hashing(List<char> charArray)
        {
            char[] myStr = sault(charArray);

            for (int i = 0; i < myStr.Length; i++)
            {
                if (i != myStr.Length - 1) myStr[i] += myStr[i + 1];
                if (i != 0 && i != myStr.Length) myStr[i] += myStr[i - 1];
                myStr[i] = (char)filter(myStr[i]);
            }

            return new string(myStr);
        }

        public char[] sault(List<char> charArray)
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
