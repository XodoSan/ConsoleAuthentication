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
            Program program = new();
            WordGenerator wordGenerator = new();

            List<string> hashs;
            List<string> newWords = new();

            Console.WriteLine("Enter ur password: ");
            newWords.Add(Console.ReadLine());

            hashs = program.GetHashs(newWords);

            Console.WriteLine(hashs[0]);
        }

        public int filter(int x)
        {
            while (true)
            {
                if (x < 35) x = (x * x % 19) + 35;
                else if (x > 126) x = x % 126;
                else return x;
            }
        }

        public string Hashing(List<char> charArray)
        {
            char[] myStr = sault(charArray);

            for (int i = 0; i < myStr.Length; i++)
            {
                if (i != 0) myStr[i] += myStr[i - 1];
                else myStr[i] += myStr[i + 1];
                myStr[i] = (char)filter(myStr[i]);
            }

            for (int i = myStr.Length - 1; i >= 0; i--)
            {
                if (i != myStr.Length - 1) myStr[i] += myStr[i + 1];
                else myStr[i] += myStr[i - 1];
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

        public List<string> GetHashs(List<string> newWords)
        {
            Program program = new();

            List<string> hashs = new();
            List<char> charArray;

            for (int i = 0; i < newWords.Count(); i++)
            {
                charArray = newWords[i]
                    .ToCharArray()
                    .ToList();

                hashs.Add(program.Hashing(charArray));
            }

            return hashs;
        }

        public List<string> FillingWordsArray(int iterations)
        {
            WordGenerator wordGenerator = new();

            List<string> words = new();

            for (int i = 0; i < iterations; i++)
            {
                words.Add(wordGenerator.GenerateWord());
            }

            return words;
        }
    }
}
