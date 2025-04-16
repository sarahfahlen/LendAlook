using System.Collections.Generic;
using Core;

namespace ServerAPI.Repository;

public interface IClosetRepository
{
    tøj[] GetAll();
    void Add(tøj item);
    void Remove(int id);

    void Update(tøj item);

    bruger[] GetAllUsers();
}