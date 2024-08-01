using ApiNotes.Context;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        private readonly NoteService _services;

        public NoteController(AppDbContext context)
        {
            _services = new NoteService(context);
        }
    }
}
