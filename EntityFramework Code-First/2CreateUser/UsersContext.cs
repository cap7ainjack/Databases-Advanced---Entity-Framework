namespace _2CreateUser
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersContext : DbContext
    {
        // Your context has been configured to use a 'UsersContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_2CreateUser.UsersContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UsersContext' 
        // connection string in the application configuration file.
        public UsersContext()
            : base("name=UsersContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Town> Towns { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany();



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