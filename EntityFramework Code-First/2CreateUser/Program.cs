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

            using (context)
            {
                try
                {
                    // ProccessingTags(context);

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

        private static void ProccessingTags(UsersContext context)
        {
            string input = Console.ReadLine();

            Tag tag = new Tag()
            {
                TagLabel = input
            };

            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {

                tag.TagLabel = TagTransormer.Transform(tag.TagLabel);
                context.SaveChanges();
            }
        }
    }
}
