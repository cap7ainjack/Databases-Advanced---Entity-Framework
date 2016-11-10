namespace _3HotelDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    public class HotelDBContext : DbContext
    {
        // Your context has been configured to use a 'HotelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_3HotelDB.HotelDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HotelDB' 
        // connection string in the application configuration file.
        public HotelDBContext()
            : base("name=HotelDB")
        {

        }

        public DbSet<BedType> BedTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Occupancie> Occupancies { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomStatus> RoomStatuses { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}