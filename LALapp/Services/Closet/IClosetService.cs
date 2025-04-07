using Core;
namespace LALapp;
public interface IClosetService
{
    Task<tøj[]> GetAll();
    Task AddItem(tøj item);
    Task DeleteById(int id);
    Task UpdateItem(tøj item);
    Task BookItem(tøj item, DateOnly slutDato);
    Task FilterBy(string? type, string? farve, string? størrelse, bruger? udlåner, bool? ledig);

}