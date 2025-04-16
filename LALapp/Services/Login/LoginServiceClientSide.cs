using Blazored.LocalStorage;
using Core;

namespace LALapp.Services;

public class LoginServiceClientSide : ILoginService
{
    private ILocalStorageService localStorage { get; set; }

    public LoginServiceClientSide(ILocalStorageService ls)
    {
        localStorage = ls;
    }

    public static bruger rip = new bruger
        { id = 1, brugernavn = "rip", password = "1234", email = "rip@rip.com", mobil = 76546789 };

    public static bruger rap = new bruger
        { id = 2, brugernavn = "rrp", password = "4321", email = "rap@rap.com", mobil = 87907652 };

    public static bruger rup = new bruger
        { id = 3, brugernavn = "rup", password = "qwerty", email = "rup@rup.com", mobil = 64572358 };

    public async Task<bruger?> GetUserLoggedIn()
    {
        bruger? res = await localStorage.GetItemAsync<bruger>("user");
        return res;
    }
    
    public async Task<bool> Login(string brugernavn, string password)
    {
        bruger? u = await Validate(brugernavn, password);
        if (u != null)
        {
            u.password = "validated";
            await localStorage.SetItemAsync("user", u);
            return true;
        }

        return false;
    }

    public static List<bruger> users = new List<bruger> { rip, rap, rup };

    protected virtual async Task<bruger?> Validate(string username, string password)
    {
        foreach (bruger u in users)

            if (username.Equals(u.brugernavn) && password.Equals(u.password))
                return u;

        return null;
    }

    public async Task<bruger[]> GetAll()
    {
        return users.ToArray();
    }
}