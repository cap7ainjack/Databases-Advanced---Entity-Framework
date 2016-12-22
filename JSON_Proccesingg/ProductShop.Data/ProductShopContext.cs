namespace ProductShop.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasMany(user => user.Friends)
                    .WithMany()
                    .Map(userFriends =>
                    {
                        userFriends.MapLeftKey("UserId");
                        userFriends.MapRightKey("FriendId");
                        userFriends.ToTable("UserFriends");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }


}