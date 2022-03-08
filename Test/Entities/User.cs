namespace UserAuthorization.Entities
{
    public class User
    {
        public User(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }

        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
