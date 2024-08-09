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
    public class PathController : ControllerBase, IControllerPattern<Paths>
    {
        private readonly IUnitOfWork _uof;
        public PathController(IUnitOfWork _uof)
        {
            this._uof = _uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paths>> Get()
        {
            return Ok(_uof.PathsService.Get());
        }

        [HttpGet("/{id:int}")]
        public ActionResult<Paths> GetId(int id)
        {
            return Ok(_uof.PathsService.GetId(n => n.Id == id));
        }

        [HttpPost]
        public ActionResult<Paths> Post(Paths entidade)
        {
            _uof.PathsService.Post(entidade);
            return new CreatedAtRouteResult("ObterPasta", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Paths> Put(int id, Paths t)
        {
            return Ok(_uof.PathsService.Put(t));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Paths> Delete(int id)
        {
            return Ok(_uof.PathsService.Delete(_uof.PathsService.GetId(n => n.Id == id)));
        }

        [HttpGet("/notes{id:int}")]
        public ActionResult<Paths>? GetNoteForPath(int id)
        {
            
            return Ok(_uof.PathsService.GetNoteForPath(id));

        }
    }
}
