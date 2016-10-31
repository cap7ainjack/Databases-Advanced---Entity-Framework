namespace _3EmployeesFullInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempTemplate")]
    public partial class TempTemplate
    {
        [Key]
        [Column(Order = 0)]
        public int EmployeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }

        public int? ManagerID { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal Salary { get; set; }

        public int? AddressID { get; set; }
    }
}
