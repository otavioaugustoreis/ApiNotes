using ApiNotes.Context;
using ApiNotes.Controllers.Interfaces;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase, IControllerPattern<Note>
    {
        private readonly IUnitOfWork _uof;
        public NoteController(IUnitOfWork _uof)
        {
            this._uof = _uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            return Ok(_uof.NoteService.Get());
        }
        [HttpGet("{id:int}")]
        public ActionResult<Note> GetId(int id)
        {
            return Ok(_uof.NoteService.GetId(n => n.Id == id));
        }

        [HttpPost]
        public ActionResult<Note> Post(Note entidade)
        {
            _uof.NoteService.Post(entidade);
            return new CreatedAtRouteResult("ObterCategoria", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Note> Put(int id, Note t)
        {
            return Ok(_uof.NoteService.Put(t));      
        }
       
        [HttpDelete("{id:int}")]
        public ActionResult<Note> Delete(int id)
        {
            return Ok(_uof.NoteService.Delete(_uof.NoteService.GetId(n => n.Id == id)));
        }

    }
}
