using System.Collections.Generic;
using UserAuthorization.Entities;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.UserLocations
{
    public interface IOnLoginMenu
    {
        public (Status, List<User>) CallLoginMenu(List<User> users);
    }
}
