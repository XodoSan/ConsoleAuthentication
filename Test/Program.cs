using System.Collections.Generic;
using UserAuthorization.Entities;
using UserAuthorization.Statuses;
using static UserAuthorization.Constants.ConstantUserInteractions;

namespace Test
{
    class Program
    {
        static void Main()
        {
            OnMainMenu onMainMenu = new();
            OnLoginMenu onLoginMenu = new();
            List<User> users = new();
            Status status;

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
