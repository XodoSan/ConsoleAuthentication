using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;

namespace UserAuthorization.AuthServices.ResetPasswordService
{
    public class ResetPassword: IResetPassword
    {
        private readonly IAuthTools _authTools;
        private readonly IUserHandler _userHandler;

        public ResetPassword(IAuthTools authTools, IUserHandler userHandler)
        {
            _authTools = authTools;
            _userHandler = userHandler;
        }

        public (int, List<User>) ResetUserPassword(List<User> users, string nickname)
        {
            if (_userHandler.IsUserExists(users, nickname))
            {
                int thisIndex = users.Select(user => user.Nickname).ToList().IndexOf(nickname);
                users[thisIndex].Password = "";

                _authTools.RecreateFile(users);
                Console.WriteLine($"User: {nickname} has empty password!");
            }
            else
            {
                Console.WriteLine("This user does not exist!");
            }

            return (2, users);
        }
    }
}
