using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class DSLR_Camera : Camera
    {
        //•	Make – mandatory information
        //•	Model – mandatory information
        //•	Is Full Frame or Not
        //•	Min ISO – integer number that cannot be lower than 100 or not set.Mandatory information
        //•	Max ISO
        //•	Max Shutter Speed – integer number

        public int MaxShutterSpeed { get; set; }
    }
}
