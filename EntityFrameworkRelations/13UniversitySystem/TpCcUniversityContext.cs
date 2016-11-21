using _13UniversitySystem.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13UniversitySystem
{
    public class TpCcUniversityContext : DbContext
    {
        public TpCcUniversityContext()
            : base("name=TpCcUniversityContext")
        {
        }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(person => person.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Student>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Teachers");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
