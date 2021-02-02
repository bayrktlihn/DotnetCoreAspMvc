using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }



        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //      optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=weqe;Uid=root;Pwd=parolagelecek;");
        // }
    }
}