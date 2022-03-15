using System;
using System.Collections.Generic;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;

namespace UserAuthorization.AuthServices.RegistrationService
{
    public class Registration: IRegistration
    {
        private readonly IUserHandler _userHandler;
        private readonly IAuthTools _authTools;

        public Registration(IUserHandler userHandler, IAuthTools authTools)
        {
            _userHandler = userHandler;
            _authTools = authTools;
        }

        public List<User> UserRegistration(List<User> users)
        {
            Console.WriteLine("Enter your nickname, password and repeat password to sign up");
            Console.Write("Enter your nickname: ");
            string nickname = Console.ReadLine();

            if (!_userHandler.IsUserExists(users, nickname))
            {
                int attemps = 3;

                for (int i = 0; i < attemps; i++)
                {
                    Console.Write("Enter password: ");
                    string enteredPassword = _authTools.EnterHidePassword();

                    Console.Write("Repeat your password: ");
                    string confirmPassword = _authTools.EnterHidePassword();

                    if (!_userHandler.IsEqualPasswords(enteredPassword, confirmPassword))
                    {
                        Console.WriteLine($"Attempts left: {attemps - i}");
                        continue;
                    }

                    _authTools.FileWriting(new User(nickname, enteredPassword, false));
                    users = _authTools.FileReading();

                    Console.WriteLine("Registation successfuly!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("This nickname is already used");
                Console.WriteLine("You can login to your account");
                Console.WriteLine("Or enter a different nickname");
            }

            return users;
        }
    }
}
