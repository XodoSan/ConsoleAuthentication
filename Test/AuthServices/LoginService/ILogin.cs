using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.LoginService
{
    public interface ILogin
    {
        public (int, List<User>) UserLogin(List<User> users);
    }
}
