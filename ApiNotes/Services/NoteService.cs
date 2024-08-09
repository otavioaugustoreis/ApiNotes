using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNotes.Services
{
    public class NoteService : Repository<Note>, INote
    {
        public NoteService(AppDbContext context) : base(context)
        {
        }
    }
}
