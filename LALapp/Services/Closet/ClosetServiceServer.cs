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
        return await client.GetFromJsonAsync<tøj[]>($"{serverUrl}/api/closetPage");
    }
    
    public async Task AddItem(tøj closet)
    {
        await client.PostAsJsonAsync<tøj>($"{serverUrl}/api/closetPage", closet);
    }
    
    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{serverUrl}/api/closetPage/{id}");
    }

    public Task UpdateItem(tøj item)
    {
        throw new NotImplementedException();
    }

    public Task BookItem(tøj item, DateOnly slutDato)
    {
        throw new NotImplementedException();
    }

    public Task FilterBy(string? type, string? farve, string? størrelse, bruger? udlåner, bool? ledig)
    {
        throw new NotImplementedException();
    }
}