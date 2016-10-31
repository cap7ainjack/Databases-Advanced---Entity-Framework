namespace MiniORMLive
{
    using System;
    using CustomORM.Core;
    using MiniORMLive.Entities;

    class Program
    {
        static void Main()
        {
            string connectionString = new ConnectionStringBuilder("MyWebSiteDatabase").ConnectionString;
            IDbContext context = new EntityManager(connectionString, true);

            User user = new User("Gosho", "asd", 12, DateTime.Now);
            context.Persist(user);
        }
    }
}
