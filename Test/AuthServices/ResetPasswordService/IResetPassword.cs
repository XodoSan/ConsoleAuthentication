using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.ResetPasswordService
{
    public interface IResetPassword
    {
        public (int, List<User>) ResetUserPassword(List<User> users, string nickname);
    }
}
