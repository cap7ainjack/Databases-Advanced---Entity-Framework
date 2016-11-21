namespace _1CodeFirstStudentSystem
{
    using Models;
    using System.Data.Entity;

    public class StudentSystemContext : DbContext
    {
        // Your context has been configured to use a 'StudentSystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_1CodeFirstStudentSystem.StudentSystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentSystemContext' 
        // connection string in the application configuration file.
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resourse> Resourses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<License> Licenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Homework>(c => c.Homeworks)
                .WithRequired(homework => homework.Student);

            base.OnModelCreating(modelBuilder);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}