using System;

namespace UserAuthorization.Constants
{
    public class ConstantMessages
    {
        public void ToCorrectCommands()
        {
            Console.WriteLine("To execute a command, enter its name in the console");
        }

        public void ToWelcome()
        {
            Console.WriteLine("Hello! You can enter sign in, sign up or info");
            Console.WriteLine("Enter out to close program");
        }

        public void ToWrongCommand()
        {
            Console.WriteLine("Invalid command");
        }

        public void ToGetInfo()
        {
            Console.WriteLine("This is Laba #2, task 3");
            Console.WriteLine("Admin of this task: Andrew Shvetsov BI-21");
        }

        public void ToRegistration()
        {
            Console.WriteLine("Enter your nickname, password and repeat password to sign up");
        }

        public void ToEnterNickname()
        {
            Console.WriteLine("Enter your nickname");
        }

        public void ToEnterPassword()
        {
            Console.WriteLine("Enter your password");
        }

        public void IfUsedNickname()
        {
            Console.WriteLine("This nickname is already used");
            Console.WriteLine("You can login to your account");
            Console.WriteLine("Or enter a different nickname");
        }

        public void ToAvailableAttemps(int attemps)
        {
            Console.WriteLine($"Attempts left: {attemps - 1}");
        }

        public void ToSuccessfuly()
        {
            Console.WriteLine("Successfuly!");
        }

        public void ToLogin()
        {
            Console.WriteLine("Enter your nickname and password to sign in your account");
        }

        public void ToNotExistUser()
        {
            Console.WriteLine("This user does not exist");
            Console.WriteLine("To register, go to the main menu");
        }

        public void ToLoginMenu()
        {
            Console.WriteLine("You success sign in your account!");
            Console.WriteLine("Enter, \"change\" to change password");
            Console.WriteLine("Enter, \"out\" to out from you account");
        }

        public void ToChangePassword()
        {
            Console.WriteLine("You need to enter a your last password to change him");
        }

        public void ToWrongPassword()
        {
            Console.WriteLine("Wrong password!");
        }
    }
}
