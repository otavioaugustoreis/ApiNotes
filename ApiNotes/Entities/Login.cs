using ApiNotes.Entities.Abstracts;
using ApiNotes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ApiNotes.Entities
{
   
    public class Login : BaseEntity
    {

        private Login() { }

        public Login( int id, string name, DateTime dateOfInclusion, string? password, User user) : base(id, name, dateOfInclusion)
        {
            this.password = password;
            this.User = user;
            this.UserId = User.Id;
        }

        [Column("ds_senha")]
        public string? password { get; set; }

        [Required]
        [Column("fk_user")]
        public int? UserId { get; set; }

        public User User { get; set; }
    }
}
