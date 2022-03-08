using System.Collections.Generic;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Constants;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices
{
    public class Registration
    {
        ConstantMessages constantMessages = new();
        ConstantUserInteractions constantUserInteractions = new();
        UserHandler userHandler = new();

        public List<User> UserRegistration(List<User> users)
        {
            constantMessages.ToRegistration();
            constantMessages.ToEnterNickname();
            string nickname = constantUserInteractions.ToEnterData();

            if (userHandler.IsNewUser(users, nickname))
            {
                for (int attemps = 3; attemps > 0; attemps--)
                {
                    constantMessages.ToEnterPassword();
                    string enteredPassword = constantUserInteractions.ToEnterData();

                    constantMessages.ToEnterPassword();
                    string confirmPassword = constantUserInteractions.ToEnterData();

                    if (!userHandler.IsEqualPasswords(enteredPassword, confirmPassword))
                    {
                        constantMessages.ToAvailableAttemps(attemps);
                    }
                    else
                    {
                        users.Add(new User(nickname, enteredPassword));
                        constantMessages.ToSuccessfuly();
                        return users;
                    }
                }
            }
            else
            {
                constantMessages.IfUsedNickname();
            }

            return users;
        }
    }
}
