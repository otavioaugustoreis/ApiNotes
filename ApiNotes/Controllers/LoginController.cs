using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces.InterfacesController;
using ApiNotes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _services;

        public LoginController(AppDbContext context)
        {
            _services = new LoginService(context);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Login> Delete(int id)
        {
            try
            {
                Login login = _services.Delete(id);

                if (login is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Login>> Get()
        {
            var list = _services.Get();
            //Any(), verifica se uma lista está vazia
            if(list is null || !list.Any())
            {
                throw new Exception("Lista vazia");
            }   
            
            return Ok(list);
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Login> GetId(int id)
        {
            try
            {
                Login login  = _services.GetId(id);
                return Ok(login);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }

        }

        [HttpPost]
        public ActionResult<Login> Post(Login entidade)
        {
            try
            {
                Login login = _services.Post(entidade); 
                return Ok(login);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<Login> Put(int id, Login entidade)
        {
            try
            {
                var list = _services.Put(id,entidade);
                return Ok(list);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }
    }
}
