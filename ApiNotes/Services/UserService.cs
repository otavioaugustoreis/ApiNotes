using ApiNotes.Context;
using ApiNotes.Entities;
using ApiNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNotes.Services
{
    public class UserService : Repository<User>, IUser
    {
        public UserService(AppDbContext context) : base(context)
        {
        }
    }
}
