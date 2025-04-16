using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repository;
using Core;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IClosetRepository closetRepo;

        public UserController(IClosetRepository closetRepo)
        {
            this.closetRepo = closetRepo;
        }

        [HttpGet]
        public IEnumerable<bruger> GetAllUsers()
        {
            return closetRepo.GetAllUsers();
        }
    }
}