using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3HotelDB
{
    class Program
    {
        static void Main()
        {
            var context = new HotelDBContext();

            using (context)
            {

            }
        }
    }
}
