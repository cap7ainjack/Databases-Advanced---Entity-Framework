namespace _2CreateUser.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2CreateUser.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_2CreateUser.UsersContext";
        }

        protected override void Seed(_2CreateUser.UsersContext context)
        {
            context.Users.AddOrUpdate<User>
            (u => u.Username,
            new User()
            {
                Username = "Dr_Who",
                Password = "WhoWho11@",
                Age = 33,
                BornTown = new Town() { Name = "Vidin", Country = "Bulgaria" },
                Email = "abvTo@abv.bg",
                CurrentlyLivingTown = context.Towns.First(t => t.Id == 1),
                LastTimeLoggedIn = DateTime.Now,
                RegistedOn = new DateTime(2016, 4, 11),
                ProfilePicture = File.ReadAllBytes("C:\\Projects SoftUni 3\\DatabasesAdvanced\\Databases-Advanced---Entity-Framework\\EntityFramework Code-First\\2CreateUser\\obj\\images.jpg")

            });
        }
    }
}
