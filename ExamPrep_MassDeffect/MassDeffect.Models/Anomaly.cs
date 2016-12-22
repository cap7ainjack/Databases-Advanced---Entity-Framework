using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDeffect.Models
{
    public class Anomaly
    {
        private ICollection<Person> victims;

        public Anomaly()
        {
            victims = new HashSet<Person>();
        }

        public int Id { get; set; }

        public int? OriginPlanetId { get; set; }

        public int? TeleportPlanetId { get; set; }

        [ForeignKey("OriginPlanetId")]
        [InverseProperty("OriginAnomalies")]
        public virtual Planet OriginPlanet { get; set; }

        [InverseProperty("TeleportAnomalies")]
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims
        {
            get { return this.victims; }
            set { this.victims = value; }
        }
    }
}
