using System;

namespace HashingAlghoritm
{
    public class WordGenerator
    {
        public string GenerateWord()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

            Random rand = new Random();

            string word = "";
            int num_letters = rand.Next(5, 15);

            for (int j = 1; j <= num_letters; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);

                word += letters[letter_num];
            }

            return word;
        }
    }
}
