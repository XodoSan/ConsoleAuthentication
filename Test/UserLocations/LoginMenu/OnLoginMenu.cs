using System;
using System.Collections.Generic;
using UserAuthorization.AuthServices.ChangePasswordService;
using UserAuthorization.Entities;
using UserAuthorization.UserLocations;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.Statuses
{
    public class OnLoginMenu: IOnLoginMenu
    {
        private readonly IChangePassword _changePassword;

        public OnLoginMenu(IChangePassword changePassword)
        {
            _changePassword = changePassword;
        }

        public (Status, List<User>) CallLoginMenu(List<User> users)
        {
            int status;

            Console.WriteLine("You success sign in your account!");
            Console.WriteLine("Enter, \"change\" to change password");
            Console.WriteLine("Enter, \"out\" to out from you account");
            string enteredCommand = Console.ReadLine();

            switch (enteredCommand)
            {
                case "change":
                    (status, users) = _changePassword.UserChangePassword(users);
                    return ((Status) status, users);
                case "out":
                    return ((Status) 0, users);
                default:
                    Console.WriteLine("Invalid command");
                    return ((Status) 1, users);
            }
        }
    }
}
