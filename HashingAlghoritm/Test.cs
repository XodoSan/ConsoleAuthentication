using System.Collections.Generic;
using System.Linq;

namespace HashingAlghoritm
{
    public class Test
    {
        public int CollisionTest(List<string> hashs)
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
    }
}
