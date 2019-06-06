namespace JwtWAspNetCore.Services.Interfaces
{
    using JwtWAspNetCore.Domain;

    public interface IUserRepository
    {
        User ValidateUser(User user);
    }
}
