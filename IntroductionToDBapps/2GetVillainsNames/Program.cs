using System;
using System.Data.SqlClient;

namespace _2GetVillainsNames
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=.;Database=Minions_DB_VS; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string nameSelection = "SELECT V.Name, COUNT(M.MinionID) FROM [dbo].Villains AS v " +
                                        "INNER JOIN[dbo].Minions AS m " +
                                        "ON M.VillainsID = V.VillainsID " +
                                        "GROUP BY V.Name " +
                                        "HAVING COUNT(M.MinionID) > 3" +
                                        "order by count(v.MinionID)desc";


                SqlCommand command = new SqlCommand(nameSelection, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + " ");
                    }

                    Console.WriteLine();
                }

            }

        }
    }
}
