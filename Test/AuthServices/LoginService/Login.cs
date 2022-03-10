using System;
using System.Collections.Generic;
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
            Console.WriteLine("Enter your nickname");
            string nickname = Console.ReadLine();

            if (_userHandler.IsUserExists(users, nickname))
            {
                int attemps = 3;

                for (int i = 0; i < attemps; i++)
                {
                    Console.WriteLine("Enter your password");
                    string enteredPassword = Console.ReadLine();

                    User thisUser = new User(nickname, enteredPassword);
                    if (!_userHandler.IsCorrectPassword(users, thisUser))
                    {
                        Console.WriteLine($"Attempts left: {attemps - i}");
                        continue;
                    }

                    users = _authTools.MoveToBegin(users, thisUser);

                    Console.WriteLine("Login successfuly!");
                    return (1, users);
                }
            }
            else
            {
                Console.WriteLine("This user does not exist");
                Console.WriteLine("You should be registred, go to the main menu to do that");
                return (0, users);
            }

            return (2, users);
        }
    }
}
