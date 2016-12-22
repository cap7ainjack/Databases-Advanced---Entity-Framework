using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Workshop
    {
        //•	Name – mandatory information
        //•	Start date 
        //•	End date 
        //•	Location – mandatory information
        //•	Price Per Participant – mandatory information
        //•	Trainer - any photographer.Mandatory information
        //•	Participants – many photographers
        private ICollection<Photographer> participants;

        public Workshop()
        {
            this.participants = new HashSet<Photographer>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal PricePerParticipant { get; set; }

        public int TrainerId { get; set; }

        [Required]
        [InverseProperty("WorkshopsTrainedIn")]
        public virtual Photographer Trainer { get; set; }

        public ICollection<Photographer> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }

    }
}
