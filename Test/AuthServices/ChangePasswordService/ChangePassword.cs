using System;
using System.Collections.Generic;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;

namespace UserAuthorization.AuthServices.ChangePasswordService
{
    public class ChangePassword: IChangePassword
    {
        private readonly IUserHandler _userHandler;
        private readonly IAuthTools _authTools;

        public ChangePassword(IUserHandler userHandler, IAuthTools authTools)
        {
            _userHandler = userHandler;
            _authTools = authTools;
        }

        public (int, List<User>) UserChangePassword(List<User> users)
        {
            string enteredPassword;

            Console.WriteLine("You need to enter a your last password to change him");
            Console.Write("Enter your password: ");
            enteredPassword = Console.ReadLine();

            if (_userHandler.IsEqualPasswords(users[0].Password, enteredPassword))
            {
                Console.Write("Enter your new password: ");
                enteredPassword = Console.ReadLine();
                
                users[0].Password = enteredPassword;
                _authTools.RecreateFile(users);

                return (1, users);
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

            return (1, users);
        }
    }
}
