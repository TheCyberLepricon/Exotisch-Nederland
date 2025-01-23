using Console_app_exotisch_nederland.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console_app_exotisch_nederland.Data

{
    public class DataProgram
    {
        private readonly string _connectionString = @"sqlite://tempdb_acces:Ex0tischNL1!@20.4.44.177:22/tempdatabase.db";
        //server=lweprican;Table=sdjfuiw;user=medewerker;password=djfsnhjhfq;
        public void KillYourSelf()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
        }
        public void VoegDierToe(Organisme.Dier dier)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string insertQuery = @"
                INSERT INTO InheemseSoort (Naam, Soort_id, Oorsprong, OrganismeAfkomst, Omschrijving, Locatie_id, Datum, AantalWaarnemingen)
                VALUES (@Naam, @Soort, @Oorsprong, @Afkomst, @Beschrijving, @Latitude, @Longitude, @Datum);";

            using var command = new SqliteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Naam", dier.NaamDier);
            command.Parameters.AddWithValue("@Soort", dier.Type);
            command.Parameters.AddWithValue("@Oorsprong", dier.Oorsprong);
            command.Parameters.AddWithValue("@Longitude", dier.Afkomst);
            command.Parameters.AddWithValue("@Beschrijving", dier.Beschrijving);
            command.Parameters.AddWithValue("@Latitude", dier.Latitude);
            command.Parameters.AddWithValue("@Longitude", dier.Longitude);
            command.Parameters.AddWithValue("@Datum", dier.DatumTijd);



            command.ExecuteNonQuery();
        }
        public List<Organisme.TotaalOrganismes> HaalAlleOrganismeSoortenOp()
        {
            var soorten = new List<Organisme.TotaalOrganismes>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string selectQuery = @"
                SELECT * FROM Registraties;";
            using var command = new SqliteCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string naam = reader.GetString(0);
                string type = reader.GetString(1);
                string oorsprong = reader.GetString(2);
                string afkomst = reader.GetString(3);
                string datumTijd = reader.GetString(4);
                string latitude = reader.GetString(5);
                string longitude = reader.GetString(6);
                string beschrijving = reader.GetString(7);
                string naamOrganisme = reader.GetString(8);

                soorten.Add(new Organisme.TotaalOrganismes
                    (
                    naam,
                    type,
                    oorsprong,
                    afkomst,
                    datumTijd,
                    latitude,
                    longitude,
                    naamOrganisme,
                    beschrijving
                    
                    ));
            }
            return soorten;
        }
    }
}
