namespace _1CodeFirstStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        //[InverseProperty("Course")] 
        // it is used when one class have at least TWO connection to other class
        //Example: If this student.cs have Regular Course and ExtraCourse then
        //Courses also should have collections of StudentsWithRegularCourses and StudentsWithExtraCourses
        //then inverse property should be used on all four connections:

        //[InverseProperty("RegularCourse")] 
        //publuc virtual ICollection<Student> StudentsWithRegularCourses{get;set;} 
    }
}
