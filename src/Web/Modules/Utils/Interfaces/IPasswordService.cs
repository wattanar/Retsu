namespace Web.Modules.Utils.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password, string salt);
        string RandomPassword(int passwordLength);
    }
}