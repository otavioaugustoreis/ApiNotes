using ApiNotes.Context;
using ApiNotes.Controllers.Interfaces;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using ApiNotes.Interfaces.InterfacesController;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ApiNotes.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase, IControllerPattern<Login>
    {
        private readonly IUnitOfWork _uof;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Login>> Get()
        {
            return Ok(_uof.LoginService.Get());
        }

        [HttpGet("login/{id:int}")]
        public ActionResult<Login> GetId(int id)
        {
            return Ok(_uof.LoginService.GetId(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult<Login> Post(Login entidade)
        {
            _uof.LoginService.Post(entidade);
            return new CreatedAtRouteResult("ObterCategoria", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Login> Put(int id, Login login)
        {
            return Ok(_uof.LoginService.Put(login));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Login> Delete(int id)
        {
            Login entidade = _uof.LoginService.GetId(p => p.Id == id);

            return Ok(_uof.LoginService?.Delete(entidade));
        }


        [HttpGet("usuario/{id:int}")]
        public ActionResult<Login> ConsultarUsuarioPorLogin(int id)
        {
            return Ok(_uof.LoginService.ConsultarLoginPorUsuario(id));
        }
        }
    }

