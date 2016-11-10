using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB.Models
{
    public class BedType
    {
        // BedTypes(BedType, Notes)
        public enum Types
        {
            Small,
            Medium,
            Big,
            VeryBig
        }

        public int Id { get; set; }

        public Types Type { get; set; }

        public string Notes { get; set; }

    }
}
