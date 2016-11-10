using _2CreateUser.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2CreateUser
{
    class Program
    {
        static void Main()
        {
            UsersContext context = new UsersContext();

            Town town = new Town()
            {
                Name = "Sliven",
                Country = "Bulgaria"
            };

            //User newUser = new User()
            //{
            //    Username = "Pantata",
            //    Password = "panteleI22@",
            //    Email = "pantelei22@abv.bg",
            //    RegistedOn = DateTime.Now,
            //    LastTimeLoggedIn = DateTime.Now,
            //    Age = 25,
            //    ProfilePicture = File.ReadAllBytes("C:\\Users\\user\\Downloads\\spitz.jpg")
            //};

            using (context)
            {
                try
                {
                    //var user = context.Users.First();
                    //user.BornTown = town;
                    //user.CurrentlyLivingTown = new Town()
                    //{
                    //    Name = "Varna",
                    //    Country = "Bulgaria"
                    //};
                }
                catch (DbEntityValidationException ex)
                {

                    foreach (var item in ex.EntityValidationErrors)
                    {
                        foreach (var item2 in item.ValidationErrors)
                        {
                            Console.WriteLine(item2.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
