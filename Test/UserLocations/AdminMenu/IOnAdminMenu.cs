using System.Collections.Generic;
using UserAuthorization.Entities;
using static UserAuthorization.Tools.AuthTools;

namespace UserAuthorization.UserLocations.AdminMenu
{
    public interface IOnAdminMenu
    {
        public (Status, List<User>) CallAdminMenu(List<User> users);
    }
}
