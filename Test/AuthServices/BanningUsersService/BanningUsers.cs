using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;

namespace UserAuthorization.AuthServices.BanningUsersService
{
    public class BanningUsers: IBanningUsers
    {
        private readonly IAuthTools _authTools;
        private readonly IUserHandler _userHandler;
        public BanningUsers(IAuthTools authTools, IUserHandler userHandler)
        {
            _authTools = authTools;
            _userHandler = userHandler;
        }

        public (int, List<User>) ChangeUserBanStatus(List<User> users, string nickname)
        {
            if (_userHandler.IsUserExists(users, nickname))
            {
                int thisIndex = users.Select(user => user.Nickname).ToList().IndexOf(nickname);
                users[thisIndex].IsBanned = !users[thisIndex].IsBanned;

                _authTools.RecreateFile(users);
                Console.WriteLine($"User {nickname} successfuly change ban status!");
            }
            else
            {
                Console.WriteLine("This user does not exist!");
            }
            
            return (2, users);
        }
    }
}
