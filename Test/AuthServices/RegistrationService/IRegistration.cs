using System.Collections.Generic;
using UserAuthorization.Entities;

namespace UserAuthorization.AuthServices.RegistrationService
{
    public interface IRegistration
    {
        public List<User> UserRegistration(List<User> users);
    }
}
