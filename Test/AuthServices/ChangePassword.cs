using System.Collections.Generic;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Constants;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices
{
    public class ChangePassword
    {
        ConstantMessages constantMessages = new();
        ConstantUserInteractions constantUserInteractions = new();
        UserHandler userHandler = new();

        public (int, List<User>) UserChangePassword(List<User> users)
        {
            string enteredPassword;

            constantMessages.ToChangePassword();
            constantMessages.ToEnterPassword();
            enteredPassword = constantUserInteractions.ToEnterData();

            if (userHandler.IsEqualPasswords(users[0].Password, enteredPassword))
            {
                constantMessages.ToEnterPassword();
                enteredPassword = constantUserInteractions.ToEnterData();
                users[0].Password = enteredPassword;

                return (1, users);
            }
            else
            {
                constantMessages.ToWrongPassword();
            }

            return (0, users);
        }
    }
}
