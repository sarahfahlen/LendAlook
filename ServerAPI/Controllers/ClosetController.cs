using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repository;
using Core;
namespace ServerAPI.Controllers;

public class ClosetController
{
    [ApiController]
    [Route("api/closetPage")]
    public class ToDoController : ControllerBase
    {
        private IClosetRepository closetRepo;

        public ToDoController(IClosetRepository todoRepo)
        {
            this.closetRepo = todoRepo;
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
        
        [HttpDelete]
        [Route("{id}")]
        public void Remove(int id)
        {
            Console.WriteLine($"Sletter tøj med id {id}");
            closetRepo.Remove(id);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] bool isDone)
        {
            var existingItem = closetRepo.GetAll().FirstOrDefault(t => t.id == id);
            if (existingItem == null)
                return NotFound("Tøj item not found");

            closetRepo.Update(id, isDone);
            return Ok();
        }

    }
}