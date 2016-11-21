using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13UniversitySystem.Models
{

    //[Table("Teachers")] - instead of TpT Model builder
    public class Teacher : Person
    {
        //•	Teacher - first name, last name, phone number, email, salary per hour
        private ICollection<Course> courses;

        public Teacher()
        {
            this.courses = new HashSet<Course>();
        }

        [Required]
        public string Email { get; set; }

        public decimal SalaryPerHour { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
