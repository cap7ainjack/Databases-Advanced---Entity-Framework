using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Len
    {
        //          •	Make
        //          •	Focal Length – integer number, represents the focal lentgth in milimeters
        //          •	Max Aperture – floating point number precise 1 digit after decimal point
        //          •	Compatible With – make of the camera that the lens is compatible with
        //          •	Owner – could be any photographer


        public int Id { get; set; }

        public string Make { get; set; }

        public int FocalLength { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public double MaxAperture { get; set; }

        public string CompatibleWith { get; set; }

        public virtual Photographer Owner { get; set; }
    }
}
