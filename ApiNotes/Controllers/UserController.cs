using ApiNotes.Context;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _services;

        public UserController(AppDbContext context)
        {
            _services = new UserService(context);
        }
    }
}
