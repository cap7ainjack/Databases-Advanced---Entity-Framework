using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Category
    {
        //•	Categories have an id and name (from 3 to 15 characters)
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }


        public int CategoryId { get; set; }

        [Required, MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }

            set { this.products = value; }
        }
    }
}
