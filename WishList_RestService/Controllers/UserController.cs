using Microsoft.AspNetCore.Mvc;
using User_RestService.Models;
using User_RestService.Services;

namespace User_RestService.Controllers
{
    [Route("user-api")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Route("names")]
        [HttpPost]
        public IActionResult GetNames(Users users)
        {
            return Ok(_service.CollectNames(users));
        }
    }
}
