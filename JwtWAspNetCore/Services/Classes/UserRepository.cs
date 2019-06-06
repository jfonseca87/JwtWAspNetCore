namespace JwtWAspNetCore.Services.Classes
{
    using System.Linq;
    using JwtWAspNetCore.Domain;
    using JwtWAspNetCore.Services.Interfaces;

    public class UserRepository : IUserRepository
    {
        private readonly ApiContext db;

        public UserRepository(ApiContext db)
        {
            this.db = db;
        }

        public User ValidateUser(User user)
        {
            User userDb = db.Users.FirstOrDefault(x => x.UserName.ToLower().Trim().Equals(user.UserName.ToLower().Trim()) &&
                                                       x.Password.ToLower().Trim().Equals(user.Password.ToLower().Trim()) && 
                                                       x.Active);

            return userDb;
        }
    }
}
