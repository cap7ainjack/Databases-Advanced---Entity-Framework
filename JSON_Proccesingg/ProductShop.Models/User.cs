using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class User
    {
        //•	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).
        private ICollection<Product> boughtProducts;
        private ICollection<Product> soldProducts;
        private ICollection<User> friends;

        public User()
        {
            this.boughtProducts = new HashSet<Product>();
            this.soldProducts = new HashSet<Product>();
            this.friends = new HashSet<User>();
        }


        public int UserId { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> BoughtProducts
        {
            get { return this.boughtProducts; }
            set { this.boughtProducts = value; }
        }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> SoldProducts
        {
            get { return this.soldProducts; }
            set { this.soldProducts = value; }
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }
    }
}
