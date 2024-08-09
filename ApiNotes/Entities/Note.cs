using ApiNotes.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ApiNotes.Entities
{

   //[Table("TB_NOTE")]
    public class Note : BaseEntity
    {
        public Note() { }
        public Note(int pathID, Paths? path, int userId, User? user)
        {
            this.PathID = _Path.Id;
            this._Path = path;
            this.UserId = userId;
            this.user = user;
        }

        [Required]
        [Column("fk_path")]
        public int? PathID { get; set; }
        public Paths? _Path { get; set; }

        [Required]
        [Column("fk_usuario")]
        public int UserId { get; set; }
        public User? user { get; set; }
    }
}
