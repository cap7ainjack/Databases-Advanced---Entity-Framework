using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1CodeFirstStudentSystem.Models
{
    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Student> students;
        private ICollection<Resourse> resources;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resourse>();
        }

        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Resourse> Resourses
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
