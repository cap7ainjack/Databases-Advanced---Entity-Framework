using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDeffect.Models
{
    public class Planet
    {
        private ICollection<Person> personLivingOn;
        private ICollection<Anomaly> originAnomalies;
        private ICollection<Anomaly> teleportAnomalies;

        public Planet()
        {
            this.personLivingOn = new HashSet<Person>();
            this.originAnomalies = new HashSet<Anomaly>();
            this.teleportAnomalies = new HashSet<Anomaly>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Star Sun { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Person> PersonsLivingOn
        {
            get { return this.personLivingOn; }
            set { this.personLivingOn = value; }
        }

        public virtual ICollection<Anomaly> OriginAnomalies
        {
            get { return this.originAnomalies; }
            set { this.originAnomalies = value; }
        }

        public virtual ICollection<Anomaly> TeleportAnomalies
        {
            get { return this.teleportAnomalies; }
            set { this.teleportAnomalies = value; }
        }
    }
}
