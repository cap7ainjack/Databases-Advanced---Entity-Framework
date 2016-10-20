using System;
using System.Data.SqlClient;

namespace _3GetMinionNames
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=.;Database=Minions_DB_VS; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                string input = Console.ReadLine();
                SelectionNamesByID(input, connection);
            }
        }

        static void SelectionNamesByID(string id, SqlConnection connection)
        {
            //villain NAME SELECTION
            string villainSelection = "SELECT V.Name FROM dbo.Villains AS v " +
                                       "WHERE V.VillainsID = ";
            SqlCommand villainCommand = new SqlCommand(villainSelection + "@id", connection);
            villainCommand.Parameters.AddWithValue("@id", id);
            villainCommand.CommandText = villainSelection + "@id";

            string villainName = villainCommand.ExecuteScalar().ToString();
            Console.WriteLine($"Villain: {villainName}");



            //MINIONS NAME SELECTION
            string minionsQuery = "SELECT m.Name, m.Age FROM [dbo].Minions as m " +
                                     "WHERE m.VillainsID = ";

            SqlCommand command = new SqlCommand(minionsQuery + "@id", connection);
              command.Parameters.AddWithValue("@id", id);
            command.CommandText = minionsQuery + "@id";
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }

            reader.Close();
        }
    }
}
