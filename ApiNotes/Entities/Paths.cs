using ApiNotes.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNotes.Entities
{
    [Table("TB_PATH")]
    public sealed class Paths : BaseEntity
    {   
        [Column("ds_descricao")]
        public string? Description { get; set; }

        [Required]
        [Column("fk_usuario")]
        public int  UserId { get; set; }

        [Required]
        [Column("fk_usuario")]
        public User? User { get; set; }

        [JsonIgnore]
        public ICollection<Note>? Notes { get; set; }
    }   
}
