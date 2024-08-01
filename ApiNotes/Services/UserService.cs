using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNotes.Services
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User Delete(int id)
        {
            User? user = _context.Users.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (user == null) return null;

            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<User> Get()
        {
            var list = _context.Users.AsNoTracking().Take(10).ToList();
            return list;       
        }

        public User GetId(int id)
        {
            User user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return user;
        }

        public User Post(User entidade)
        {
            _context.Users.Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public User Put(int id, User entidade)
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
