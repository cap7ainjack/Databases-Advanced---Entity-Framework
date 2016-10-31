using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19FirstLetter
{
    class Program
    {
        static void Main()
        {
            using (var context = new GringottsContext())
            {
                var wizardsFirstLetter = context.WizzardDeposits.Where(wz => wz.DepositGroup == "Troll Chest")
                                                        .Select(wz => wz.FirstName.Substring(0,1)).Distinct();

                foreach (var letter in wizardsFirstLetter)
                {
                    Console.WriteLine(letter);
                }

            }
        }
    }
}
