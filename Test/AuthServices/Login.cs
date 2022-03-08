using System.Collections.Generic;
using UserAuthorization.AuthServices.UserHandlers;
using UserAuthorization.Constants;
using UserAuthorization.Entities;
using System.Linq;

namespace UserAuthorization.AuthServices
{
    public class Login
    {
        ConstantMessages constantMessages = new();
        ConstantUserInteractions constantUserInteractions = new();
        UserHandler userHandler = new();

        public (int, List<User>) UserLogin(List<User> users)
        {
            constantMessages.ToLogin();
            constantMessages.ToEnterNickname();
            string nickname = constantUserInteractions.ToEnterData();

            if (!userHandler.IsNewUser(users, nickname))
            {
                for (int attemps = 3; attemps > 0; attemps--)
                {
                    constantMessages.ToEnterPassword();
                    string enteredPassword = constantUserInteractions.ToEnterData();

                    User thisUser = new User(nickname, enteredPassword);
                    if (userHandler.IsCorrectPassword(users, thisUser))
                    {
                        users = constantUserInteractions.MoveToBegin(users, thisUser);
                        
                        constantMessages.ToSuccessfuly();
                        return (1, users);
                    }
                    else
                    {
                        constantMessages.ToAvailableAttemps(attemps);
                    }
                }
            }
            else
            {
                constantMessages.ToNotExistUser();
            }

            return (0, users);
        }
    }
}
