namespace _3HotelDB.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.RegularExpressions;
    using Models;

    public class Room
    {
        //•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)

        public int Id { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 300)]
        public int Number { get; set; }

        public RoomType Type { get; set; }

        public BedType BedType { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

        public RoomStatus Status { get; set; }

        public string Notes { get; set; }

    }
}
