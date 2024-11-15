using Microsoft.EntityFrameworkCore;
using NetConf2024StudentV1.Models;

namespace NetConf2024StudentV1.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                  new Student
                  {
                      Id = 1,
                      Name = "John Doe",
                      Age = 20,
                      Email = "john.doe@example.com"
                  },
                  new Student
                  {
                      Id = 2,
                      Name = "Jane Doe",
                      Age = 22,
                      Email = "jane.doe@example.com"
                  },
                  new Student
                  {
                      Id = 3,
                      Name = "Alice Smith",
                      Age = 23,
                      Email = "alice.smith@example.com"
                  },
                  new Student
                  {
                      Id = 4,
                      Name = "Bob Johnson",
                      Age = 21,
                      Email = "bob.johnson@example.com"
                  },
                  new Student
                  {
                      Id = 5,
                      Name = "Charlie Brown",
                      Age = 24,
                      Email = "charlie.brown@example.com"
                  }
              );
        }
    }

}

