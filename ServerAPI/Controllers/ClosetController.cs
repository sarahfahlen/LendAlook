using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repository;
using Core;
namespace ServerAPI.Controllers;

[ApiController]
[Route("api/closet")]
public class ClosetController : ControllerBase
{
    private IClosetRepository closetRepo;

    public ClosetController(IClosetRepository closetRepo)
    {
        this.closetRepo = closetRepo;
    }

    [HttpGet]
    public IEnumerable<tøj> Get()
    {
        return closetRepo.GetAll();
    }

    [HttpPost]
    public void Add([FromBody] tøj item)
    {
        closetRepo.Add(item);
    }

    [HttpDelete("{id}")]
    public void Remove(int id)
    {
        Console.WriteLine($"Sletter tøj med id {id}");
        closetRepo.Remove(id);
    }

    [HttpPut]
    public void Update([FromBody] tøj item)
    {
        closetRepo.Update(item);
    }
}