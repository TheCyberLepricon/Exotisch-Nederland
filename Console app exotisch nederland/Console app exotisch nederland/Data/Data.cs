using Console_app_exotisch_nederland.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;
using static Console_app_exotisch_nederland.Models.Organisme;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console_app_exotisch_nederland.Data

{
    public class DataProgram
    {
        private readonly string _connectionString = @"Data Source=""C:\Users\Gebruiker\Downloads\Tussendatabase.db"";";//Verander dit naar de locatie van de database op jouw computer
        private readonly string _hoofdConnectionString = @"Data Source=""C:\Users\Gebruiker\Downloads\Hoofddatabase.db"";";//Verander dit naar de locatie van de database op jouw computer
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
                INSERT INTO Registraties (DierOfPlant, Soort, Oorsprong, Afkomst, DatumTijd, Lengtegraad, Breedtegraad, NaamOrganisme,Beschrijving)
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

            using var connection = new SqliteConnection(_hoofdConnectionString);
            connection.Open();
            string query = @"
            SELECT 
            W.Waarneming_id,
            W.NaamOrganisme,
            W.DierOfPlant,
            W.Oorsprong,
            W.Afkomst,
            W.Aantal_registraties,
            S.Soort AS SoortNaam,
            R.DatumTijd,
            L.Lengtegraad,
            L.Breedtegraad,
            B.Beschrijving AS BeschrijvingTekst
            FROM 
            Waarnemingen W
            JOIN 
            Soorten S ON W.Soort_id = S.Soort_id
            JOIN 
            Registraties R ON W.Waarneming_id = R.Waarneming_id
            JOIN 
            Locaties L ON R.Locatie_id = L.Locatie_id
            JOIN 
            Beschrijvingen B ON R.Beschrijving_id = B.Beschrijving_id;
            ";
            using var command = new SqliteCommand(query, connection);   

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string dierOfPlant = reader.GetString(reader.GetOrdinal("DierOfPlant"));
                string type = reader.GetString(reader.GetOrdinal("SoortNaam"));
                string oorsprong = reader.GetString(reader.GetOrdinal("Oorsprong"));
                string afkomst = reader.GetString(reader.GetOrdinal("Afkomst"));
                string datumTijd = reader.GetString(reader.GetOrdinal("DatumTijd"));
                double latitude = reader.GetDouble(reader.GetOrdinal("Lengtegraad"));
                double longitude = reader.GetDouble(reader.GetOrdinal("Breedtegraad"));
                string beschrijving = reader.GetString(reader.GetOrdinal("BeschrijvingTekst"));
                string naamOrganisme = reader.GetString(reader.GetOrdinal("NaamOrganisme"));
                
                

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
