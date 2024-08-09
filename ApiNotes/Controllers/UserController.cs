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
    public class UserController : ControllerBase, IControllerPattern<User>
    {
        private readonly IUnitOfWork _uof;
        public UserController(IUnitOfWork _uof)
        {
            this._uof = _uof;
        }

        //Get ta Ok()
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_uof.UserService.Get());

        }

        //Ok()
        [HttpGet("user/{id:int}")]
        public ActionResult<User> GetId(int id)
        {
            return Ok(_uof.UserService.GetId(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult<User> Post(User entidade)
        {
            //Fazer validações
            _uof.UserService.Post(entidade);
            _uof.Commit();  
            return new CreatedAtRouteResult("ObterCategoria", new { id = entidade.Id }, entidade);
            
        }

        [HttpPut("{id:int}")]
        public ActionResult<User> Put(int id, User t)
        {
            _uof.UserService.Put(t);
            _uof.Commit();
            return Ok();
            
        }


        [HttpDelete("{id:int}")]
        public ActionResult<User> Delete(int id)
        {
            User entidade = _uof.UserService.GetId(p => p.Id == id);
            _uof.UserService?.Delete(entidade);
            _uof.Commit() ;
            return Ok();
        }
    }
}
