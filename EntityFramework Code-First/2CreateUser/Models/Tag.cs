using _2CreateUser.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2CreateUser.Models
{
    public class Tag
    {
        private ICollection<Album> albums;

        public Tag()
        {
            this.albums = new HashSet<Album>();
        }

        public int TagId { get; set; }

        [Required, Tag]
        public string TagLabel { get; set; }

        public ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
