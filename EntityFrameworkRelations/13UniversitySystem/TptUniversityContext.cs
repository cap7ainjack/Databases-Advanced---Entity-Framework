using _13UniversitySystem.Models;
using System.Data.Entity;

namespace _13UniversitySystem
{
    public class TptUniversityContext : DbContext
    {
        public TptUniversityContext()
            : base("name=TptUniversityContext")
        {

        }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachars");

            base.OnModelCreating(modelBuilder);
        }
    }
}
