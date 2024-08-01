using ApiNotes.Context;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly PathService _services;

        public PathController(AppDbContext context)
        {
            _services = new PathService(context);
        }
    }
}
