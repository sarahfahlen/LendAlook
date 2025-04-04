using Core;
namespace LALapp;
public interface IClosetService
{
    Task<tøj> GetAll();
    Task AddItem();
    Task DeleteById();
    Task UpdateItem();
    Task BookItem();
    Task FilterBy();

}