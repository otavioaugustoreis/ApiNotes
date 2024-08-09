using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ApiNotes.Services
{
    public sealed class LoginService : Repository<Login>, ILogin
    {
        //Injeção de dependência
        //Aqui já podemos usar
        public LoginService(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Login> ConsultarLoginPorUsuario(int id)
        {
            //O método Where por padrão já retorna uma lista
            //o DbContext tem funções que exercem a mesma função no SQL, como Where, Select, OrderBy e entre outros...
            return _context.Logins
                .Include(l => l.User)
                .Where(l => l.UserId == id);
        }
    }
}
