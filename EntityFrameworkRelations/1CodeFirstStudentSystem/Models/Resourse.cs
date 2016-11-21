using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1CodeFirstStudentSystem.Models
{
    public class Resourse
    {
        public enum ResourseType
        {
            video,
            presentation,
            document,
            other
        }

        public int ResourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourseType Type { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
