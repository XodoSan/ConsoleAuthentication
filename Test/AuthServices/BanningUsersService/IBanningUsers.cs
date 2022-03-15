using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.BanningUsersService
{
    public interface IBanningUsers
    {
        public (int, List<User>) ChangeUserBanStatus(List<User> users, string nickname);
    }
}
