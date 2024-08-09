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

        //Revisar isso aqui
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Consegui PORRA !!!!!!! ae caraleo
            modelBuilder.Entity<User>()
                .HasOne(a => a._Login)
                .WithOne(u => u.User)
                .HasForeignKey<Login>(f => f.UserId);

            modelBuilder.Entity<Paths>()
                .HasMany(P => P.Notes)
                .WithOne(n => n._Path)
                .HasForeignKey(n => n.PathID);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.user)
                .WithMany(u => u._Notes)
                .HasForeignKey(f => f.UserId);

             base.OnModelCreating(modelBuilder);
        }

    }
}
