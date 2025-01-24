using Console_app_exotisch_nederland.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;
using static Console_app_exotisch_nederland.Models.Organisme;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console_app_exotisch_nederland.Data

{
    public class DataProgram
    {
        private readonly string _connectionString = @"Data Source=""C:\Users\lars0\Downloads\Tussendatabase.db"";";
        //server=lweprican;Table=sdjfuiw;user=medewerker;password=djfsnhjhfq;
        public void OrganismeSoortRepository()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
        }
        public void VoegPlantToe(Organisme.Plant plant)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string insertQuery = @"
                INSERT INTO Registraties (dierOfPlant, Soort, Oorsprong, Afkomst, DatumTijd, Lengtegraad, Breedtegraad, NaamOrganisme,Beschrijving)
                VALUES (@dierOfPlant, @Soort, @Oorsprong, @Afkomst, @Datum, @Latitude, @Longitude, @NaamOrganisme, @Beschrijving);";

            using var command = new SqliteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Soort", plant.Type);
            command.Parameters.AddWithValue("@Oorsprong", plant.Oorsprong);
            command.Parameters.AddWithValue("@Afkomst", plant.Afkomst);
            command.Parameters.AddWithValue("@Beschrijving", plant.Beschrijving);
            command.Parameters.AddWithValue("@Latitude", plant.Latitude);
            command.Parameters.AddWithValue("@Longitude", plant.Longitude);
            command.Parameters.AddWithValue("@Datum", plant.DatumTijd);
            command.Parameters.AddWithValue("@dierOfPlant", plant.DierOfPlant);
            command.Parameters.AddWithValue("@NaamOrganisme", plant.NaamPlant);



            command.ExecuteNonQuery();
        }
        public void VoegDierToe(Organisme.Dier dier)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string insertQuery = @"
                INSERT INTO Registraties (dierOfPlant, Soort, Oorsprong, Afkomst, DatumTijd, Lengtegraad, Breedtegraad, NaamOrganisme,Beschrijving)
                VALUES (@dierOfPlant, @Soort, @Oorsprong, @Afkomst, @Datum, @Latitude, @Longitude, @NaamOrganisme, @Beschrijving);";

            using var command = new SqliteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Soort", dier.Type);
            command.Parameters.AddWithValue("@Oorsprong", dier.Oorsprong);
            command.Parameters.AddWithValue("@Afkomst", dier.Afkomst);
            command.Parameters.AddWithValue("@Beschrijving", dier.Beschrijving);
            command.Parameters.AddWithValue("@Latitude", dier.Latitude);
            command.Parameters.AddWithValue("@Longitude", dier.Longitude);
            command.Parameters.AddWithValue("@Datum", dier.DatumTijd);
            command.Parameters.AddWithValue("@dierOfPlant", dier.DierOfPlant);
            command.Parameters.AddWithValue("@NaamOrganisme", dier.NaamDier);



            command.ExecuteNonQuery();
        }
        public List<Organisme.TotaalOrganismes> HaalAlleOrganismeSoortenOp()
        {
            var soorten = new List<Organisme.TotaalOrganismes>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string selectQuery = @"
                SELECT *  FROM Registraties;";
            using var command = new SqliteCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string dierOfPlant = reader.GetString(1);
                string type = reader.GetString(2);
                string oorsprong = reader.GetString(3);
                string afkomst = reader.GetString(4);
                string datumTijd = reader.GetString(5);
                double latitude = reader.GetDouble(6);
                double longitude = reader.GetDouble(7);
                string beschrijving = reader.GetString(9);
                string naamOrganisme = reader.GetString(8);

                soorten.Add(new Organisme.TotaalOrganismes
                    (
                    dierOfPlant,
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
