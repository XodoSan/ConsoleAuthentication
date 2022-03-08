using System.Collections.Generic;
using UserAuthorization.AuthServices;
using UserAuthorization.Constants;
using UserAuthorization.Entities;
using static UserAuthorization.Constants.ConstantUserInteractions;

namespace UserAuthorization.Statuses
{
    public class OnMainMenu
    {
        public (Status, List<User>) ToMainMenu(List<User> users)
        {
            ConstantMessages constantMessages = new();
            ConstantUserInteractions constantUserInteractions = new();
            Registration registration = new();
            Login login = new();

            int status;

            constantMessages.ToWelcome();
            constantMessages.ToCorrectCommands();
            string enteredCommand = constantUserInteractions.ToEnterData();

            switch (enteredCommand)
            {
                case "sign in":
                    (status, users) = login.UserLogin(users);
                    return ((Status) status, users);
                case "sign up":
                    users = registration.UserRegistration(users);
                    return ((Status) 0, users);
                case "info":
                    constantMessages.ToGetInfo();
                    return ((Status) 0, users);
                case "out":
                    return ((Status) 2, users);
                default:
                    constantMessages.ToWrongCommand();
                    return ((Status) 0, users);
            }
        }
    }
}
