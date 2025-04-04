using Blazored.LocalStorage;
using Core;

namespace LALapp.Services;

public class LoginServiceClientSide : ILoginService
{
    private ILocalStorageService localStorage {get; set;}

    public LoginServiceClientSide(ILocalStorageService ls)
    {
        localStorage = ls;
    }

    public async Task<bruger?> GetUserLoggedIn() {
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
    
    private List<bruger> users = new List<bruger>()
    {
        new bruger { id = 1, brugernavn = "rip",password = "1234", email = "rip@rip.com", mobil = 76546789},
        new bruger { id = 2, brugernavn = "rap", password = "4321", email = "rap@rap.com", mobil = 87907652},
        new bruger { id = 3, brugernavn = "rup", password = "qwerty", email = "rup@rup.com", mobil = 64572358}
    };
    protected virtual async Task<bruger?> Validate(string username, string password)
    {
        foreach (bruger u in users)

            if (username.Equals(u.brugernavn) && password.Equals(u.password))
                return u;

        return null;
    }

    
}