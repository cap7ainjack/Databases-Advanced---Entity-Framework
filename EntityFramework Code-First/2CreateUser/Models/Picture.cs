using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2CreateUser.Models
{
    public class Picture
    {
        private ICollection<Album> albums;

        public Picture()
        {
            this.albums = new HashSet<Album>();
        }

        public int PictureId { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public byte[] PathOnFileSystem { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
