using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNotes.Services
{
    public class PathService : IPaths
    {
        private readonly AppDbContext _context;
        public PathService(AppDbContext context)
        {
            _context = context;
        }
       
        public Paths Delete(int id)
        {
           Paths paths = _context.Paths.AsNoTracking().FirstOrDefault(p => p.Id == id);

            _context.Paths.Remove(paths);
            _context.SaveChanges();

            return paths;
        }

        public IEnumerable<Paths> Get()
        {
            var list = _context.Paths.AsNoTracking().Take(10).ToList();
            return list;
        }

        public Paths GetId(int id)
        {
            Paths? paths = _context.Paths.AsNoTracking().FirstOrDefault(p => p.Id == id);
            return paths;
        }

        public Paths Post(Paths entidade)
        {
            _context.Paths.Add(entidade);
            _context.SaveChanges();

            return entidade;
        }

        public Paths Put(int id, Paths entidade)
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
