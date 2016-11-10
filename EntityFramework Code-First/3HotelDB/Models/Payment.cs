namespace _3HotelDB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.RegularExpressions;

    public class Payment
    {
        //•	Payments (Id, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
        //TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)

        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public string AccountNumber { get; set; }

        public DateTime FirstDateOccupied { get; set; }

        public DateTime LastDateOccupied { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue)]
        public int TotalDays { get; set; }

        [Required]
        public decimal AmountCharged { get; set; }

        [Required]
        [Range(minimum: 1.00, maximum: 99.00)]
        public double TaxRate { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal TaxAmount { get; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal PaymentTotal { get; }

    }
}
