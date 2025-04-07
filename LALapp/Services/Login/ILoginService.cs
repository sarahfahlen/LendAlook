using Core;
namespace LALapp;

public interface ILoginService
{
    Task<bruger> GetUserLoggedIn();
    
    Task<bool> Login(string brugernavn, string password);
}