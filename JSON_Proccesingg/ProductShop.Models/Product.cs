using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Product
    {
        //•	Products have an id, name (at least 3 characters), price, buyerId (optional) and sellerId as IDs of users.
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }


        public int ProductId { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual User Buyer { get; set; }

        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

    }
}
