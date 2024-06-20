namespace WebAppUser.Services
{
    public interface IPasswordHasher
    {
        string GetHashPassword(string password);
    }
}
