using System.Collections.Generic;

namespace UserAuthorization.Tools.HashingAlghoritmTool
{
    public interface IHashingAlgorithm
    {
        public string GetHash(List<char> charArray);
    }
}
