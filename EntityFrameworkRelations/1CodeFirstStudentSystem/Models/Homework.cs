using System;
using System.ComponentModel.DataAnnotations;

namespace _1CodeFirstStudentSystem.Models
{
    public class Homework
    {
        public enum ContentType
        {
            application,
            pdf,
            zip
        }

        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Student Student { get; set; }

        public int StudentId { get; set; }

        // [ForeignKey("Course")]
        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

    }
}
