using System;
using System.Data.SqlClient;

namespace _1InitialSetup
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=.;Database=Minions_DB_VS; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            using  (connection)
            {
                connection.Open();

                string queryMinions = "CREATE TABLE Minions(" +
                                "MinionID INT PRIMARY KEY," +
                                "Name VARCHAR(20)," +
                                "Age INT," +
                                "Town VARCHAR(20)," +
                                "VillainsID INT"+
                              ")";

                string queryTowns = "CREATE TABLE Towns("+
                                    "TownID INT PRIMARY KEY,"+   
                                    "Name VARCHAR(20),"+
                                     "CountryName VARCHAR(20)"+
                                ")";

                string queryVillains = "CREATE TABLE Villains (" +
                    "VillainsID INT PRIMARY KEY," +
                    "Name VARCHAR(20)," +
                     "EvilnessFactor VARCHAR(20) CHECK(EvilnessFactor in ('good', 'bad', 'evil', 'super evil'))," +
                     "MinionID INT,"+
                     "CONSTRAINT FK_Villains_Minions FOREIGN KEY(MinionID) REFERENCES Minions(MinionID)" +
                ")";

                string insertMinionsCommandString = "INSERT INTO Minions (MinionID,Name, Age, Town, VillainsID) " +
                        "VALUES " +
                        "(1,'Bob', 13, 'Sofia',1), (2,'Kevin', 14, 'Sofia',2), (3,'Steward', 19, 'Sofia',3), (4,'Petar', 30, 'Sofia',4), (5,'Lidiya', 22, 'Plovdiv',5) ";

                string insertVillainsCommandString = "INSERT INTO Villains (VillainsID,Name, EvilnessFactor, MinionID) " +
                        "VALUES " +
                        "(1,'Gru', 'super evil',1), (2,'Victor', 'evil',2), (3,'Victor Jr', 'good',3), (4,'Spongebob','bad',4), (5,'Doofenschmurtz', 'good',5)";

                string addForeignKey = "ALTER TABLE Minions " +
                        "ADD CONSTRAINT FK_Minions_Villains FOREIGN KEY(VillainsID) REFERENCES Villains(VillainsID)";

                string insertTownsCommandString = "INSERT INTO Towns (TownID,Name, CountryName) " +
                        "VALUES " +
                        "(1,'Sofia', 'Bulgaria'), (2,'Berlin', 'Germany'), (3,'Eindhoven', 'Netherlands'), (4,'Liverpool','England'), (5,'Plovdiv', 'Bulgaria') ";

                //ADDITINAL MINIONS INSERT
                    string AdditionalMinions = "INSERT INTO Minions (MinionID,Name, Age, Town, VillainsID) " +
                        "VALUES " +
                        "(6,'Bob', 13, 'Sofia',3), (7,'Kevin', 14, 'Sofia',3),(8,'Lidiya', 22, 'Plovdiv',3) ";

                string AdditionalMinions2 = "INSERT INTO Minions (MinionID,Name, Age, Town, VillainsID) " +
                      "VALUES " +
                      "(9,'Bob', 13, 'Sofia',4), (10,'Kevin', 14, 'Sofia',4),(11,'Lidiya', 22, 'Plovdiv',4) ";

                SqlCommand command = new SqlCommand(AdditionalMinions2, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
