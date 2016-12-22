using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductShop.Client
{
    class Program
    {
        static void Main()
        {
            // SeedData();

            GetProductsInRange();


        }

        private static void GetProductsInRange()
        {
            ProductShopContext context = new ProductShopContext();

            //query1
            var productsInRange = context.Products
                                                  .Where(pr => pr.Price >= 500 && pr.Price <= 1000 && pr.Buyer == null)
                                                  .OrderBy(pr => pr.Price)
                                                  .Select(pr => new
                                                  {
                                                      name = pr.Name,
                                                      price = pr.Price,
                                                      sellerName = pr.Seller.FirstName + " " + pr.Seller.LastName
                                                  });

            string jsonOutputPath = "../../../Output files/ProductsInRange.json";
            var productsAsJson = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            File.WriteAllText(jsonOutputPath, productsAsJson);

        }

        private static void SeedData()
        {
            // SeedUsers();
            // SeedProducts();
            // SeedCategories();
        }

        private static void SeedUsers()
        {
            ProductShopContext context = new ProductShopContext();
            string jsonUserPath = File.ReadAllText("../../../ProductShop.DataSets/users.json");
            ICollection<User> users = JsonConvert.DeserializeObject<ICollection<User>>(jsonUserPath);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

        }

        private static void SeedCategories()
        {
            ProductShopContext context = new ProductShopContext();

            string jsonCategoriesPath = File.ReadAllText("../../../ProductShop.DataSets/Categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategoriesPath);

            int productsCount = context.Products.Count();
            Random rnd = new Random();

            foreach (Category category in categories)
            {
                var products = context.Products.ToArray();
                for (int i = 0; i < productsCount / 4; i++)
                {
                    category.Products.Add(products[rnd.Next(1, productsCount + 1)]);
                }
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private static void SeedProducts()
        {
            ProductShopContext context = new ProductShopContext();
            string productsPath = File.ReadAllText("../../../ProductShop.DataSets/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productsPath);

            Random random = new Random();
            int usersCount = context.Users.Count();
            foreach (var product in products)
            {
                product.Seller = context.Users.Find(random.Next(1, usersCount + 1));
                double buyerFactor = random.NextDouble();
                if (buyerFactor <= 0.7)
                {
                    product.Buyer = context.Users.Find(random.Next(1, usersCount + 1));
                }

                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
