using System.Collections.Generic;
using UserAuthorization.Entities;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.UserLocations.MainMenu
{
    public interface IOnMainMenu
    {
        public (Status, List<User>) CallMainMenu(List<User> users);
    }
}
