using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB.Models
{
    public class Customer
    {
        //•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmergencyName { get; set; }

        public string EmergencyNumber { get; set; }

        public string Notes { get; set; }

    }
}
