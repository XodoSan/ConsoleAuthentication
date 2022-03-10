using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.ChangePasswordService
{
    public interface IChangePassword
    {
        public (int, List<User>) UserChangePassword(List<User> users);
    }
}
