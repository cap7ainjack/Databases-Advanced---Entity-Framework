using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Accessory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Photographer Owner { get; set; }
    }
}
