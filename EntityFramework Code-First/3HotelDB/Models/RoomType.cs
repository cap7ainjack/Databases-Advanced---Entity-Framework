using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB.Models
{
   public  class RoomType
    {
       public enum MyEnum
        {
            OneBed,
            TwoBeds,
            ThreeBeds,
            Mansion,
            VIP
        };

        public int Id { get; set; }

        public MyEnum Type { get; set; }
    }
}
