namespace _13UniversitySystem
{
    using Models;
    using System.Data.Entity;

    public class TphUniversityContext : DbContext
    {
        // Your context has been configured to use a 'TphUniversityContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_13UniversitySystem.TphUniversityContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TphUniversityContext' 
        // connection string in the application configuration file.
        public TphUniversityContext()
            : base("name=TphUniversityContext")
        {
        }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}