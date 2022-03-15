namespace UserAuthorization.Entities
{
    public class User
    {
        public User(string nickname, string password, bool isBanned)
        {
            Nickname = nickname;
            Password = password;
            IsBanned = isBanned;
        }

        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool IsBanned { get; set; }
    }
}
