using ApiNotes.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNotes.Entities
{
    
    public sealed class User : BaseEntity
    {
        [Required(ErrorMessage = "O e-mail é obrgatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido")]
        [Column("ds_email")]
        [StringLength(70)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória")]
        [Range(10,100)]
        [Column("nr_idade")]
        public int Age { get; set; }

        [JsonIgnore]
        public  ICollection<Paths>? Paths { get; set; }

        [JsonIgnore]
        public Login Login { get; set; }
    }
}
