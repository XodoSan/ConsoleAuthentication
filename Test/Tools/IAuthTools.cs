using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.Tools
{
    public interface IAuthTools
    {
        public List<User> MoveToBegin(List<User> users, User thisUser);
        public void FileWriting(User user);
        public List<User> FileReading();
        public void RecreateFile(List<User> users);
        public string EnterHidePassword();
    }
}
