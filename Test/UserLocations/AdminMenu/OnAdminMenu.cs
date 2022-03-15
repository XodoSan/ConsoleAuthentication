using System;
using System.Collections.Generic;
using UserAuthorization.AuthServices.BanningUsersService;
using UserAuthorization.AuthServices.BrowsingUsersService;
using UserAuthorization.AuthServices.ChangePasswordService;
using UserAuthorization.AuthServices.ResetPasswordService;
using UserAuthorization.Entities;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.UserLocations.AdminMenu
{
    public class OnAdminMenu: IOnAdminMenu
    {
        private readonly IBrowsingUsers _browsingUsers;
        private readonly IChangePassword _changePassword;
        private readonly IResetPassword _resetPassword;
        private readonly IBanningUsers _banningUsers;

        public OnAdminMenu
        (
            IBrowsingUsers browsingUsers, 
            IChangePassword changePassword, 
            IResetPassword resetPassword,
            IBanningUsers banningUsers
        )
        {
            _browsingUsers = browsingUsers;
            _changePassword = changePassword;
            _resetPassword = resetPassword;
            _banningUsers = banningUsers;
        }

        public (Status, List<User>) CallAdminMenu(List<User> users)
        {
            int status; 

            Console.WriteLine("Hel. Oh. You Admin... Don't ban me :O");
            Console.WriteLine("You can view all users - \"view\"");
            Console.WriteLine("Reset the password for the selected user - \"reset\"");
            Console.WriteLine("Change your password - \"change\"");
            Console.WriteLine("Change ban status selected user - \"ban\"");
            Console.WriteLine("Or out the program - \"out\"");
            string command = Console.ReadLine();

            Console.Clear();

            switch (command)
            {
                case "view":
                    _browsingUsers.DisplayUsers(users);
                    return ((Status) 2, users);
                case "change":
                    (status, users) = _changePassword.UserChangePassword(users);
                    return ((Status) 2, users);
                case "reset":
                    Console.Write("Enter user nickname: ");
                    string nickname = Console.ReadLine();

                    (status, users) = _resetPassword.ResetUserPassword(users, nickname);

                    return ((Status) 2, users);
                case "ban":
                    Console.Write("Enter user nickname: ");
                    nickname = Console.ReadLine();

                    _banningUsers.ChangeUserBanStatus(users, nickname);

                    return ((Status) 2, users);
                case "out":
                    return ((Status) 0, users);
                default:
                    Console.WriteLine("Invalid command");
                    return ((Status) 2, users);
            }
        }
    }
}
