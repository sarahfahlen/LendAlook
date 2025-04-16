using System.Net.Http.Json;
using Core;

namespace LALapp.Services;

public class ClosetServiceServer : IClosetService
{
    private string serverUrl = "http://localhost:5265";

    private HttpClient client;

    public ClosetServiceServer(HttpClient client)
    {
        this.client = client;
    }

    public async Task<tøj[]> GetAll()
    {
        return await client.GetFromJsonAsync<tøj[]>($"{serverUrl}/api/closet");
    }

    public async Task AddItem(tøj closet)
    {
        await client.PostAsJsonAsync<tøj>($"{serverUrl}/api/closet", closet);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{serverUrl}/api/closet/{id}");
    }

    public async Task UpdateItem(tøj item)
    {
        await client.PutAsJsonAsync($"{serverUrl}/api/closet", item);
    }


    public async Task BookItem(tøj item, DateTime? slutDato)
    {
        await UpdateItem(item);
    }

    public Task FilterBy(string? type, string? farve, string? størrelse, bruger? udlåner, bool? ledig)
    {
        throw new NotImplementedException();
    }

    public async Task<bruger[]> GetAllUsers()
    {
        return await client.GetFromJsonAsync<bruger[]>($"{serverUrl}/api/users");
    }
}