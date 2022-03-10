﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using UserAuthorization.Entities;

namespace UserAuthorization.Tools
{
    public class AuthTools: IAuthTools
    {
        public const string path = "db.txt";

        public enum Status
        {
            StayOnMainMenu = 0,
            StayOnLoginMenu = 1,
            Out = 2
        }

        public List<User> MoveToBegin(List<User> users, User thisUser)
        {
            User copuUser = users[0];
            int thisIndex = users.Select(user => user.Nickname).ToList().IndexOf(thisUser.Nickname);
            users[0] = thisUser;
            users[thisIndex] = copuUser;

            return users;
        }

        public void FileWriting(User user)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteAsync(user.Nickname);
                writer.WriteAsync(" ");
                writer.WriteLineAsync(user.Password);
            }
        }

        public void RecreateFile(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < users.Count(); i++)
                {
                    writer.WriteAsync(users[i].Nickname);
                    writer.WriteAsync(" ");
                    writer.WriteLineAsync(users[i].Password);
                }
            }
        }

        public List<User> FileReading()
        {
            List<User> users = new();

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(new User(line.Split(" ")[0], line.Split(" ")[1]));
                }
            }

            return users;
        }
    }
}