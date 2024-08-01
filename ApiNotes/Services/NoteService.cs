using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNotes.Services
{
    public class NoteService : INote
    {

        private readonly AppDbContext _context;
        public NoteService(AppDbContext context)
        {
            _context = context;
        }

        public Note Delete(int id)
        {
            Note note = _context.Notes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _context.Notes.Remove(note); 
            _context.SaveChanges();
            return note;
        }

        public IEnumerable<Note> Get()
        {
            var list = _context.Notes.AsNoTracking().Take(10).ToList();
            return list;
        }

        public Note GetId(int id)
        {
            Note note = _context.Notes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return note;
        }

        public Note Post(Note entidade)
        {
            _context.Notes.Add(entidade);
            _context.SaveChanges();
            
            return entidade;
        }

        public Note Put(int id, Note entidade)
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
