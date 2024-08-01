using ApiNotes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiNotes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /*Dbset eu seto para mostrar o que é tabela e o que não é, ou seja, aqio*/

        public DbSet<User>?                   Users  { get; set; }
        public DbSet<Login>?                  Logins { get; set; }
        public DbSet<Paths>?                  Paths  { get; set; }
        public DbSet<Note>?                   Notes  { get; set; }
    }
}
