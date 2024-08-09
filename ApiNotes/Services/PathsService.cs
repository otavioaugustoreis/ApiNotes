using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiNotes.Services
{
    public sealed class PathsService : Repository<Paths>, IPaths
    {
        //Injeção de dependência
        public PathsService(AppDbContext context) : base(context)
        {
        }

        public Paths GetNoteForPath(int id)
        {
            return _context.Paths
                .Include(i => i.Notes)
                .FirstOrDefault(i => i.Id == id);
                
        }

    }
}
