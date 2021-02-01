using Microsoft.EntityFrameworkCore;
using MyProject.Entity;
using System;

namespace MyProject.Data
{
    public class MyContext : DbContext
    {


        public DbSet<Person> People { get; set; }
        
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
            
        }

        public MyContext()
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=myDataBase;Uid=root;Pwd=parolagelecek;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.Gender).HasConversion<String>();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.Gender).HasMaxLength(5);
            
        }
    }
}