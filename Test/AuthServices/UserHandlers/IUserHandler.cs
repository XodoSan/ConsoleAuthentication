using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.UserHandlers
{
    public interface IUserHandler
    {
        public bool IsUserExists(List<User> users, string nickname);
        public bool IsEqualPasswords(string password, string confirmPassword);
        public bool IsCorrectPassword(List<User> users, User user);
    }
}
