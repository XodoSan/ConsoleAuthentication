using System;
using System.Collections.Generic;
using System.Linq;
using UserAuthorization.Entities;

namespace UserAuthorization.Constants
{
    public class ConstantUserInteractions
    {
        public string ToEnterData()
        {
            string data = Console.ReadLine();

            return data;
        }

        public enum Status
        {
            StayOnMainMenu = 0,
            StayOnLoginMenu = 1,
            Out = 2,
            StayOnChange = 3
        }

        public List<User> MoveToBegin(List<User> users, User thisUser)
        {
            User copuUser = users[0];
            int thisIndex = users.Select(user => user.Nickname).ToList().IndexOf(thisUser.Nickname);
            users[0] = thisUser;
            users[thisIndex] = copuUser;

            return users;
        }
    }
}
