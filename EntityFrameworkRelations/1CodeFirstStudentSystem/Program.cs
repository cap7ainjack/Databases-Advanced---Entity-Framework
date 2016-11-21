using System;
using System.Linq;

namespace _1CodeFirstStudentSystem
{
    class Program
    {
        static void Main()
        {
            //Database.SetInitializer(
            //  new Mig)

            var context = new StudentSystemContext();

            using (context)
            {
                // context.Database.Initialize(true);

                //5.	For each student, calculate the number of courses ...
                var students = context.Students;

                foreach (var student in students)
                {
                    int numberOfCourses = student.Courses.Count();
                    decimal totalPriceForCourses = student.Courses.Sum(s => s.Price);
                    decimal averagePriceOnCourse = student.Courses.Average(s => s.Price);

                    Console.WriteLine($"{student.Name} Courses Count: {numberOfCourses} Total Price: {totalPriceForCourses} Average Course Price: {averagePriceOnCourse}");
                }
            }
        }
    }
}
