using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public abstract class Camera
    {
        //•	Make – mandatory information
        //•	Model – mandatory information
        //•	Is Full Frame or Not
        //•	Min ISO – integer number that cannot be lower than 100 or not set.Mandatory information
        //•	Max ISO
        private ICollection<Photographer> primaryOwners;
        private ICollection<Photographer> secondaryOwners;

        public Camera()
        {
            this.primaryOwners = new HashSet<Photographer>();
            this.secondaryOwners = new HashSet<Photographer>();
        }


        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        [Required]
        [Range(100, int.MaxValue)]
        public int MinIso { get; set; }

        public int MaxIso { get; set; }

        public int OwnerId { get; set; }

        public ICollection<Photographer> PrimaryOwners
        {
            get { return this.primaryOwners; }
            set { this.primaryOwners = value; }
        }

        public ICollection<Photographer> SecondaryOwners
        {
            get { return this.secondaryOwners; }
            set { this.secondaryOwners = value; }
        }
    }
}
