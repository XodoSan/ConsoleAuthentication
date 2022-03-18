using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Tools;
using UserAuthorization.Tools.HashingAlghoritmTool;

namespace UserAuthorization.AuthServices.ChangePasswordService
{
    public class ChangePassword: IChangePassword
    {
        private readonly IUserHandler _userHandler;
        private readonly IAuthTools _authTools;
        private readonly IHashingAlgorithm _hashingAlgorithm;

        public ChangePassword
        (
            IUserHandler userHandler, 
            IAuthTools authTools, 
            IHashingAlgorithm hashingAlgorithm
        )
        {
            _userHandler = userHandler;
            _authTools = authTools;
            _hashingAlgorithm = hashingAlgorithm;
        }

        public (int, List<User>) UserChangePassword(List<User> users)
        {
            string enteredPassword;

            Console.WriteLine("You need to enter a your last password to change him");
            Console.Write("Enter your password: ");
            enteredPassword = _authTools.EnterHidePassword();

            List<char> charArrayPassword = enteredPassword
                            .ToCharArray()
                            .ToList();

            enteredPassword = _hashingAlgorithm.GetHash(charArrayPassword);

            if (_userHandler.IsEqualPasswords(users[0].Password, enteredPassword))
            {
                Console.Write("Enter your new password: ");
                enteredPassword = _authTools.EnterHidePassword();

                if (enteredPassword.Length < 2)
                {
                    Console.WriteLine("Password must be longer than two simbols");
                    return (1, users);
                }

                charArrayPassword = enteredPassword
                            .ToCharArray()
                            .ToList();

                enteredPassword = _hashingAlgorithm.GetHash(charArrayPassword);

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
