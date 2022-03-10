using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.UserHandlers
{
    public class UserHandler: IUserHandler
    {
        public bool IsUserExists(List<User> users, string nickname)
        {
            if (users.Select(user => user.Nickname).Contains(nickname))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEqualPasswords(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCorrectPassword(List<User> users, User user)
        {
            if (users.Where(item => item.Nickname == user.Nickname).ToList()[0].Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
