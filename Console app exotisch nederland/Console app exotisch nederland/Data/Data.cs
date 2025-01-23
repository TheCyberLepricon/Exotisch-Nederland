using Microsoft.Data.Sqlite;
using System.Globalization;

namespace Console_app_exotisch_nederland.Data

{
    public class DataProgram
    {
        private readonly string _connectionString = @"sqlite://tempdb_acces:Ex0tischNL1!@20.4.44.177:22/tempdatabase.db";
        //server=lweprican;Table=sdjfuiw;user=medewerker;password=djfsnhjhfq;
        public KillYourSelf()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
        }
        public void VoegOrganismeToe(InheemseSoort inheemseSoort)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string insertQuery = @"
                INSERT INTO InheemseSoort (Naam, LocatieNaam, Longitude, Latitude, Datum)
                VALUES (@Naam, @LocatieNaam, @Longitude, @Latitude, @Datum);";

            using var command = new SqliteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Naam", inheemseSoort.Naam);
            command.Parameters.AddWithValue("@LocatieNaam", inheemseSoort.LocatieNaam);
            command.Parameters.AddWithValue("@Longitude", inheemseSoort.Longitude);
            command.Parameters.AddWithValue("@Latitude", inheemseSoort.Latitude);
            command.Parameters.AddWithValue("@Datum", inheemseSoort.Datum);


            command.ExecuteNonQuery();
        }
        public List<InheemsSoort> HaalAlleInheemseSoortenOp()
        {
            var soorten = new List<InheemseSoort>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string selectQuery = @"
                SELECT * FROM InheemseSoort;";
            using var command = new SqliteCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string naam = reader.GetString(0);
                string locatieNaam = reader.GetString(1);
                decimal longitude = reader.GetDecimal(2);
                decimal latitude = reader.GetDecimal(3);
                string datum = reader.GetString(4);
                soorten.Add(new InheemseSoort
                    (
                    naam,
                    locatieNaam,
                    longitude,
                    latitude,
                    DateTime.ParseExact(datum, "yyyy-MM-dd-hh", System.Globalization.CultureInfo.InvariantCulture)
                    ));
            }
            return soorten;
        }
    }
}
