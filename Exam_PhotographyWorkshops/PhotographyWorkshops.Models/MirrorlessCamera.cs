using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class MirrorlessCamera : Camera
    {
        //•	Make – mandatory information
        //•	Model – mandatory information
        //•	Is Full Frame or Not
        //•	Min ISO – integer number that cannot be lower than 100 or not set.Mandatory information
        //•	Max ISO
        //•	Max Video Resolution – will be inserted as plain text
        //•	Max frame rate – integer number

        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }
    }
}
