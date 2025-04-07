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
        private IClosetRepository todoRepo;

        public ToDoController(IClosetRepository todoRepo)
        {
            this.todoRepo = todoRepo;
        }
        
        [HttpGet]
        public IEnumerable<tøj> Get()
        {
            return todoRepo.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] tøj item)
        {
            todoRepo.Add(item);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void Remove(int id)
        {
            Console.WriteLine($"Sletter todo med id {id}");
            todoRepo.Remove(id);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] bool isDone)
        {
            var existingItem = todoRepo.GetAll().FirstOrDefault(t => t.id == id);
            if (existingItem == null)
                return NotFound("ToDo item not found");

            todoRepo.Update(id, isDone);
            return Ok();
        }

    }
}