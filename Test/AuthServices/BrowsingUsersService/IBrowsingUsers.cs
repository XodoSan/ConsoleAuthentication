using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.BrowsingUsersService
{
    public interface IBrowsingUsers
    {
        public void DisplayUsers(List<User> users);
    }
}
