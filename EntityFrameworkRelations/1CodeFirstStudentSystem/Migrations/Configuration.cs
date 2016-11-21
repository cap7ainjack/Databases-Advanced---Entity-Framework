namespace _1CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<_1CodeFirstStudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_1CodeFirstStudentSystem.StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course()
                {
                    Name = "OOP Basics",
                    StartDate = new DateTime(2017, 2, 16),
                    Description = "Classes, Objects, Interfaces",
                    EndDate = new DateTime(2017, 3, 1),
                    Price = 200.00m,

                });

            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course()
                {
                    Name = "OOP Advanced",
                    StartDate = new DateTime(2017, 3, 1),
                    Description = "Dependency Injections, Refactoring, Unit Tests",
                    EndDate = new DateTime(2017, 4, 12),
                    Price = 220.00m,

                });

            context.Students.AddOrUpdate(
                st => st.Name,
                new Student()
                {
                    Name = "Georgi Georgiev",
                    Birthday = new DateTime(1987, 9, 15),
                    RegistrationDate = new DateTime(2016, 9, 30),
                    PhoneNumber = "+359885050225"
                });

            context.Students.AddOrUpdate(
                st => st.Name,
                new Student()
                {
                    Name = "Ivelina Ivanova",
                    Birthday = new DateTime(1992, 5, 9),
                    RegistrationDate = new DateTime(2017, 1, 30),
                    PhoneNumber = "+359885052122"
                });

            //context.Students.First(s => s.StudentId == 3)
            //    .Homeworks
            //        .Add(new Homework()
            //        {
            //            Course = context.Courses.First(c => c.CourseId == 4),
            //            Content = "Refactoring",
            //            SubmissionDate = DateTime.Now,
            //            Type = Homework.ContentType.zip

            //        });
            // context.Students.First(st => st.StudentId == 5).Courses.Add(context.Courses.First(c => c.CourseId == 2));
            //context.Students.First(st => st.StudentId == 5).Courses.Add(context.Courses.First(c => c.CourseId == 4));
            //context.Students.First().Homeworks.Add(new Homework()
            //{
            //    Course = context.Courses.First(),
            //    Content = "Loops",
            //    SubmissionDate = DateTime.Now,
            //    Type = Homework.ContentType.zip
            //});

            //  context.Students.First(st => st.StudentId == 2).Courses.Add(context.Courses.First(c => c.CourseId == 1));


            //  This method will be called after migrating to the latest version.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
