using ApiNotes.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNotes.Entities
{
    //[Table("TB_PATH")]
    public sealed class Paths : BaseEntity
    {   

        public Paths() { }

        public Paths(string? description, int userId, User? user, ICollection<Note>? notes) : base()
        {
            Description = description;
            UserId = _User.Id;
            _User = user;
            Notes = notes;
        }

        [Column("ds_descricao")]
        public string? Description { get; set; }

        [Required]
        [Column("fk_usuario")]
        public int  UserId { get; set; }

        [Required]
        [Column("fk_usuario")]
        public User? _User { get; set; }
        
        [JsonIgnore]
        public ICollection<Note>? Notes { get; set; }
    }   
}
