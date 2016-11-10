using _1GringottsDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1GringottsDB
{
    class Program
    {
        static void Main()
        {
            GringottsContextVB context = new GringottsContextVB();

            WizardsDepositsVB dumbledore = new WizardsDepositsVB()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepostiCharge = 0.2,
                IsDepositExpired = false
            };

            using (context)
            {
                try
                {
                    context.WizzardDeposits.Add(dumbledore);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {

                    foreach (var item in ex.EntityValidationErrors)
                    {
                        foreach (var item2 in item.ValidationErrors)
                        {
                            Console.WriteLine(item2.ErrorMessage);
                        }
                    }
                }

            }
        }
    }
}
