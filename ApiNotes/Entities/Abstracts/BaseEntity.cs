using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ApiNotes.Entities.Abstracts
{
    public abstract class BaseEntity
    {

        public BaseEntity() { }

        protected BaseEntity(int id, string name, DateTime dateOfInclusion)
        {
            Id = id;
            Name = name;
            DateOfInclusion = dateOfInclusion;
        }

        [Key]
        [Column("pk_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [StringLength(50)]
        [Column("ds_name")]
        public string Name { get; set; }

        [Required]
        [Column("dh_inclusao")]
        public DateTime DateOfInclusion { get; set; } 
    }
}
