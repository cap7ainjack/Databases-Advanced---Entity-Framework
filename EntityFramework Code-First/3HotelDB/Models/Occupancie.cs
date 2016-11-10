using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB.Models
{
    public class Occupancie
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateOccupied { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public int AccountNumber { get; set; }

        [Range(1, 300)]
        public int RoomNumber { get; set; }

        [Range(1, 5)]
        public int RateApplied { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal PhoneCharge { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

    }
}
