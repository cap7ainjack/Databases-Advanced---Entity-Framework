using System.Collections.Generic;

namespace _13UniversitySystem.Models
{
    // [Table("Students")] -- instead of TpT ModelBuilder
    public class Student : Person
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public double AverageGrade { get; set; }

        public int Attedances { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
