using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using UserAuthorization.AuthServices.ChangePasswordService;
using UserAuthorization.AuthServices.LoginService;
using UserAuthorization.AuthServices.RegistrationService;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Entities;
using UserAuthorization.Statuses;
using UserAuthorization.Tools;
using UserAuthorization.UserLocations;
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
                .BuildServiceProvider();

            var onLoginMenu = serviceProvider.GetService<IOnLoginMenu>();
            var onMainMenu = serviceProvider.GetService<IOnMainMenu>();
            var authTools = serviceProvider.GetService<IAuthTools>();

            List<User> users = new();
            Status status;

            if (!File.Exists(path)) authTools.FileWriting(new User("Admin", ""));

            users = authTools.FileReading();
            (status, users) = onMainMenu.ToMainMenu(users);

            while (true)
            {
                switch (status)
                {
                    case Status.StayOnLoginMenu:
                        (status, users) = onLoginMenu.ToLoginMenu(users);
                        break;
                    case Status.StayOnMainMenu:
                        (status, users) = onMainMenu.ToMainMenu(users);
                        break;
                    case Status.Out:
                        return;
                }
            }
        }
    }
}
