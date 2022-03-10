using System;
using System.Collections.Generic;
using UserAuthorization.AuthServices.LoginService;
using UserAuthorization.AuthServices.RegistrationService;
using UserAuthorization.Entities;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.UserLocations.MainMenu
{
    public class OnMainMenu: IOnMainMenu
    {
        private readonly IRegistration _registration;
        private readonly ILogin _login;

        public OnMainMenu(IRegistration registration, ILogin login)
        {
            _registration = registration;
            _login = login;
        }
        
        public (Status, List<User>) ToMainMenu(List<User> users)
        {
            int status;

            Console.WriteLine("Hello! You can enter sign in, sign up or info");
            Console.WriteLine("Enter out to close program");
            string enteredCommand = Console.ReadLine();

            switch (enteredCommand)
            {
                case "sign in":
                    (status, users) = _login.UserLogin(users);
                    return ((Status) status, users);
                case "sign up":
                    users = _registration.UserRegistration(users);
                    return ((Status) 0, users);
                case "info":
                    Console.WriteLine("This is Laba #2, task 3");
                    Console.WriteLine("Admin of this task: Andrew Shvetsov BI-21");
                    return ((Status) 0, users);
                case "out":
                    return ((Status) 2, users);
                default:
                    Console.WriteLine("Invalid command");
                    return ((Status) 0, users);
            }
        }
    }
}
