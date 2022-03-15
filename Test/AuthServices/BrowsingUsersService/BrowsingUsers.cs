using System;
using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.BrowsingUsersService
{
    public class BrowsingUsers: IBrowsingUsers
    {
        public void DisplayUsers(List<User> users)
        {
            Console.WriteLine("Hello, its list of users: ");

            for (int i = 0; i < users.Count; i++)
            {
                Console.Write($"{i+1}) ");
                Console.Write($"{users[i].Nickname} ");
                Console.WriteLine(users[i].IsBanned);
            }
        }
    }
}
