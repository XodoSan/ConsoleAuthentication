using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;

namespace UserAuthorization.AuthServices.LoginService
{
    public class Login: ILogin
    {
        private readonly IUserHandler _userHandler;
        private readonly IAuthTools _authTools;

        public Login(IUserHandler userHandler, IAuthTools authTools)
        {
            _userHandler = userHandler;
            _authTools = authTools;
        }

        public (int, List<User>) UserLogin(List<User> users)
        {
            Console.WriteLine("Enter your nickname and password to sign in your account");
            Console.Write("Enter your nickname: ");
            string nickname = Console.ReadLine();

            if (_userHandler.IsUserExists(users, nickname))
            {
                int attemps = 3;

                for (int i = 0; i <= attemps; i++)
                {
                    Console.Write("Enter your password: ");
                    string enteredPassword = _authTools.EnterHidePassword();

                    User thisUser = new User(nickname, enteredPassword, users
                        .Where(user => user.Nickname == nickname)
                        .ToList()[0].IsBanned);

                    if (thisUser.IsBanned == true)
                    {
                        Console.WriteLine("You have been disconnected from the server.");
                        Console.WriteLine("Reason: Kicked and banned");
                        Console.WriteLine("PS. You have been banned by the Admin ( ");
                        break;
                    }

                    if (!_userHandler.IsCorrectPassword(users, thisUser))
                    {
                        Console.WriteLine($"Attempts left: {attemps - i}");
                        continue;
                    }

                    users = _authTools.MoveToBegin(users, thisUser);

                    Console.WriteLine("Login successfuly!");

                    if (thisUser.Nickname == "Admin") return (2, users);

                    return (1, users);
                }
            }
            else
            {
                Console.WriteLine("This user does not exist");
                Console.WriteLine("You should be registred, go to the main menu to do that");
                return (0, users);
            }

            return (3, users);
        }
    }
}
