using Core;
namespace LAL_app;
public interface IClosetService
{
    Task GetAll();
    Task AddItem();
    Task DeleteById();
    Task UpdateItem();
    Task BookItem();
    Task FilterBy();

}