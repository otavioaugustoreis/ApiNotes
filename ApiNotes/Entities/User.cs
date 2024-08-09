using ApiNotes.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNotes.Entities
{
    
    public sealed class User : BaseEntity
    {

        public User() { }
        public User(int id, string name, DateTime dateOfInclusion , string email, int age, ICollection<Paths>? paths, Login login) : base(id, name, dateOfInclusion)
        {
            Email = email;
            Age = age;
            _Paths = paths;
            _Login = login;
        }

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
        public  ICollection<Paths>? _Paths { get; set; }

        [JsonIgnore]
        public Login? _Login { get; set; }


        [JsonIgnore]
        public IEnumerable<Note>? _Notes { get; set; }
    }
}
