using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ApiNotes.Services
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public Login Delete(int id)
        {
            Login login = _context.Logins.AsNoTracking().FirstOrDefault(x => x.Id == id);

            _context.Logins.Remove(login);
            _context.SaveChanges();
            
            return login;
        }

        public IEnumerable<Login> Get()
        {
            var list = _context.Logins.ToList();
            return list;
        }

        public Login GetId(int id)
        {
            Login login = _context.Logins.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return login;
        }

        public Login Post(Login entidade)
        {
            _context.Logins.Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public Login Put(int id, Login entidade)
        {
            if (id == entidade.Id)
            {
                return null;
            }

            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();

            return entidade;
        }
    }
}
