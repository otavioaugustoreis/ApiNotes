using ApiNotes.Entities.Abstracts;
using ApiNotes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNotes.Entities
{
   
    public class Login : BaseEntity
    {
        

        [Column("ds_senha")]
        public string? password { get; set; }

        [Required]
        [Column("fk_user")]
        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}
