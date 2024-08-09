using ApiNotes.Entities;

namespace ApiNotes.Interfaces
{
    public interface IPaths : ICrud<Paths>
    {
       Paths GetNoteForPath(int id);
    }
}
