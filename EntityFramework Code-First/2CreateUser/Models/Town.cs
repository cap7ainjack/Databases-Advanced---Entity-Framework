using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2CreateUser.Models
{
    public class Town
    {
        private ICollection<User> livingUers;
        private ICollection<User> bornUsers;

        public Town()
        {
            this.livingUers = new HashSet<User>();
            this.bornUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<User> LivingUsers
        {
            get { return this.livingUers; }
            set { this.livingUers = value; }
        }

        public virtual ICollection<User> BornUsers
        {
            get { return this.bornUsers; }
            set { this.bornUsers = value; }
        }

    }
}
