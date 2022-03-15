using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using UserAuthorization.AuthServices.BanningUsersService;
using UserAuthorization.AuthServices.BrowsingUsersService;
using UserAuthorization.AuthServices.ChangePasswordService;
using UserAuthorization.AuthServices.LoginService;
using UserAuthorization.AuthServices.RegistrationService;
using UserAuthorization.AuthServices.ResetPasswordService;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Statuses;
using UserAuthorization.Tools;
using UserAuthorization.UserLocations;
using UserAuthorization.UserLocations.AdminMenu;
using UserAuthorization.UserLocations.MainMenu;
using static UserAuthorization.Tools.AuthTools;

namespace Test
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOnLoginMenu, OnLoginMenu>()
                .AddSingleton<IOnMainMenu, OnMainMenu>()
                .AddSingleton<IChangePassword, ChangePassword>()
                .AddSingleton<IUserHandler, UserHandler>()
                .AddSingleton<ILogin, Login>()
                .AddSingleton<IRegistration, Registration>()
                .AddSingleton<IAuthTools, AuthTools>()
                .AddSingleton<IOnAdminMenu, OnAdminMenu>()
                .AddSingleton<IBrowsingUsers, BrowsingUsers>()
                .AddSingleton<IResetPassword, ResetPassword>()
                .AddSingleton<IBanningUsers, BanningUsers>()
                .BuildServiceProvider();

            var onLoginMenu = serviceProvider.GetService<IOnLoginMenu>();
            var onMainMenu = serviceProvider.GetService<IOnMainMenu>();
            var authTools = serviceProvider.GetService<IAuthTools>();
            var onAdminMenu = serviceProvider.GetService<IOnAdminMenu>();

            List<User> users = new();
            Status status;

            if (!File.Exists(path)) authTools.FileWriting(new User("Admin", "", false));

            users = authTools.FileReading();
            (status, users) = onMainMenu.CallMainMenu(users);

            while (true)
            {
                switch (status)
                {
                    case Status.ToLoginMenu:
                        (status, users) = onLoginMenu.CallLoginMenu(users);
                        break;
                    case Status.ToMainMenu:
                        (status, users) = onMainMenu.CallMainMenu(users);
                        break;
                    case Status.ToAdminMenu:
                        (status, users) = onAdminMenu.CallAdminMenu(users);
                        break;
                    case Status.Out:
                        return;
                }
            }
        }
    }
}
