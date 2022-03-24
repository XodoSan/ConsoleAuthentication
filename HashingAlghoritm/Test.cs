using System.Collections.Generic;
using System.Linq;

namespace HashingAlghoritm
{
    public class Test
    {
        public int HashCollisionTest(List<string> hashs)
        {
            int collisionCounter = 0;

            for (int i = 0; i < hashs.Count(); i++)
            {
                if (hashs.Contains(hashs[i]))
                {
                    string temp = hashs[i];
                    hashs.Remove(hashs[i]);
                    if (hashs.Contains(temp)) collisionCounter++;
                }
            }

            return collisionCounter;
        }

        public List<string> WordCollisionTest(List<string> words)
        {
            List<string> newWords = new();
            
            for (int i = 0; i < words.Count(); i++)
            {
                if (words.Contains(words[i]))
                {
                    string temp = words[i];
                    newWords.Add(temp);
                    words[i] = "";

                    if (words.Contains(temp))
                    {
                        newWords.Remove(temp);
                    }
                }
            }

            return newWords;
        }
    }
}
