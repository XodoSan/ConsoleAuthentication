using System.Collections.Generic;
using UserAuthorization.AuthServices;
using UserAuthorization.Constants;
using UserAuthorization.Entities;
using static UserAuthorization.Constants.ConstantUserInteractions;

namespace UserAuthorization.Statuses
{
    public class OnLoginMenu
    {
        ConstantMessages constantMessages = new();
        ConstantUserInteractions constantUserInteractions = new();
        ChangePassword changePassword = new();

        public (Status, List<User>) ToLoginMenu(List<User> users)
        {
            int status;

            constantMessages.ToLoginMenu();
            constantMessages.ToCorrectCommands();
            string enteredCommand = constantUserInteractions.ToEnterData();

            switch (enteredCommand)
            {
                case "change":
                    (status, users) = changePassword.UserChangePassword(users);
                    return ((Status) status, users);
                case "out":
                    return ((Status) 0, users);
                default:
                    constantMessages.ToWrongCommand();
                    return ((Status) 1, users);
            }
        }
    }
}
