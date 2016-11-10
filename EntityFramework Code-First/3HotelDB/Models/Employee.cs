namespace _3HotelDB.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.RegularExpressions;

    public class Employee
    {
        //•	Employees (Id, FirstName, LastName, Title, Notes)
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

    }
}
