namespace _1CodeFirstStudentSystem.Models
{
    public class License
    {
        public int LicenseId { get; set; }

        public string Name { get; set; }

        public virtual Resourse Resource { get; set; }

        public int ResourseId { get; set; }
    }
}
