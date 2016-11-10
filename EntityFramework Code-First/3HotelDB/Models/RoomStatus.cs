using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB.Models
{
    public class RoomStatus
    {
        //•	RoomStatus (RoomStatus, Notes)

        public enum Status
        {
            Available,
            Taken
        };

        public int Id { get; set; }

        public Status CurrentStatus { get; set; }

    }
}
