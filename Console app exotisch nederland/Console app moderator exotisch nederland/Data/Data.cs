﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Business;
using Console_app_moderator_exotisch_nederland.Models;
using Microsoft.Data.Sqlite;

namespace Console_app_moderator_exotisch_nederland.Data
{
    internal class DataProgram
    {
       

        private readonly string _TussenDatabaseConnectie = @"Data Source=""/home/Gambling_Inc/database/tussendatabase.db"";";//Verander dit naar de locatie van de database op jouw computer
        private readonly string _HoofdDatabaseConnectie = @"Data Source=""/home/Gambling_Inc/database/tussendatabase.db"";";//Verander dit naar de locatie
        
        private void VerbindMetTussenDB()
        {
            using var connection = new SqliteConnection(_TussenDatabaseConnectie);
            connection.Open();
        }
        private void VerbindMetHoofdDB()
        {
            using var connection = new SqliteConnection(_HoofdDatabaseConnectie );
            connection.Open();
        }



        public List<TussenDbOrganisme> HaalTussenDatabaseOp()
        {
            List<TussenDbOrganisme> _organismeLijst = new List<TussenDbOrganisme>();

            using var connection = new SqliteConnection(_TussenDatabaseConnectie);
            connection.Open();
            string query = @"SELECT * FROM Registraties";

            using var command = new SqliteCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int registratieId = reader.GetInt32(reader.GetOrdinal("Registratie_id"));
                string naamOrganisme = reader.GetString(reader.GetOrdinal("NaamOrganisme"));
                string dierOfPlant = reader.GetString(reader.GetOrdinal("DierOfPlant"));
                string type = reader.GetString(reader.GetOrdinal("Soort"));
                string oorsprong = reader.GetString(reader.GetOrdinal("Oorsprong"));
                string afkomst = reader.GetString(reader.GetOrdinal("Afkomst"));
                string datumTijdDB = reader.GetString(reader.GetOrdinal("DatumTijd"));
                double latitude = reader.GetDouble(reader.GetOrdinal("Lengtegraad"));
                double longitude = reader.GetDouble(reader.GetOrdinal("Breedtegraad"));
                string beschrijving = reader.GetString(reader.GetOrdinal("Beschrijving"));

                string[] OpgesplitsteDatumTijd = datumTijdDB.Split("-");

                int Dag = int.Parse(OpgesplitsteDatumTijd[0]);
                int Maand = int.Parse(OpgesplitsteDatumTijd[1]);
                int Jaar = int.Parse(OpgesplitsteDatumTijd[2]);
                int Uur = int.Parse(OpgesplitsteDatumTijd[3]);

                DateTime DatumTijd = new DateTime(Jaar, Maand, Dag, Uur, 0, 0);
                string datumTijd = DatumTijd.ToString("dd-MM-yyyy-hh");
                

                _organismeLijst.Add(new TussenDbOrganisme(
                    registratieId,
                    naamOrganisme,
                    dierOfPlant,
                    type,
                    oorsprong,
                    afkomst,
                    datumTijd,
                    latitude,
                    longitude,
                    beschrijving));

            } 
            return _organismeLijst;
        

            
            
        }

        public List<TussenDbOrganisme> TussenDatabaseOrganismenLijst()
        {
            return HaalTussenDatabaseOp();
        }

        public void TussenDbAanpassen(List<TussenDbOrganisme> tussenlijst)
        {
            using var connection = new SqliteConnection(_TussenDatabaseConnectie);
            connection.Open();

            string query = @"UPDATE Registraties SET DierOfPlant = @dierOfPlant, Soort = @Soort, Oorsprong = @Oorsprong, Afkomst = @Afkomst, DatumTijd = @Datum, Lengtegraad = @Latitude, Breedtegraad = @Longitude, NaamOrganisme = @NaamOrganisme, Beschrijving = @Beschrijving WHERE Registratie_id = @Registratie_Id";

            foreach (var registratie in tussenlijst)
            {
                foreach (var haalregistratie in HaalTussenDatabaseOp())
                {
                    if (haalregistratie.RegistratieId == registratie.RegistratieId)
                    {
                        using var command = new SqliteCommand(query, connection);
                        command.Parameters.AddWithValue("@Registratie_Id", registratie.RegistratieId);
                        command.Parameters.AddWithValue("@Soort", registratie.Type);
                        command.Parameters.AddWithValue("@Oorsprong", registratie.Oorsprong);
                        command.Parameters.AddWithValue("@Afkomst", registratie.Afkomst);
                        command.Parameters.AddWithValue("@Beschrijving", registratie.Beschrijving);
                        command.Parameters.AddWithValue("@Latitude", registratie.Latitude);
                        command.Parameters.AddWithValue("@Longitude", registratie.Longitude);
                        command.Parameters.AddWithValue("@Datum", registratie.DatumTijd);
                        command.Parameters.AddWithValue("@dierOfPlant", registratie.DierOfPlant);
                        command.Parameters.AddWithValue("@NaamOrganisme", registratie.NaamOrganisme);
                        command.ExecuteNonQuery();
                    }
                }
            }
            
        }


        public List<Waarneming> HaalWaarnemingenOp()
        {
            List<Waarneming> _waarnemingenLijst = new List<Waarneming>();
            using var connection = new SqliteConnection(_HoofdDatabaseConnectie);
            connection.Open();
            string query = @"Select * From Waarnemingen";
            using var command = new SqliteCommand( query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int waarnemingId = reader.GetInt32(reader.GetOrdinal("Waarneming_id"));
                string waarnemingNaam = reader.GetString(reader.GetOrdinal("NaamOrganisme"));
                string dierOfPlant = reader.GetString(reader.GetOrdinal("DierOfPlant"));
                string type = reader.GetString(reader.GetOrdinal("Soort"));
                string oorsprong = reader.GetString(reader.GetOrdinal("Oorsprong"));
                string afkomst = reader.GetString(reader.GetOrdinal("Afkomst"));
                int aantalRegistraties = reader.GetInt32(reader.GetOrdinal("aantal_registraties"));

                _waarnemingenLijst.Add(new Waarneming(
                    waarnemingId,
                    waarnemingNaam,
                    dierOfPlant,
                    type,
                    oorsprong,
                    afkomst,
                    aantalRegistraties));
            }
            return _waarnemingenLijst;

            
        }

        public List<Registratie> HaalHoofdDatabaseRegistratiesOp()
        {
            List<Registratie> _registratieLijst = new List<Registratie>();
            using var connection = new SqliteConnection(_HoofdDatabaseConnectie);
            connection.Open();
            string query = @"Select * From Registraties";

            using var command = new SqliteCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int registratieId = reader.GetInt32(reader.GetOrdinal("Registratie_id"));
                int waarnemingId = reader.GetInt32(reader.GetOrdinal("Waarneming_id"));
                string datumTijd = reader.GetString(reader.GetOrdinal("DatumTijd"));
                double lengtegraad = reader.GetDouble(reader.GetOrdinal("Lengtegraad"));
                double breedtegraad = reader.GetDouble(reader.GetOrdinal("Breedtegraad"));
                string beschrijving = reader.GetString(reader.GetOrdinal("Beschrijving"));

                _registratieLijst.Add(new Registratie(
                    registratieId,
                    waarnemingId,
                    datumTijd,
                    lengtegraad,
                    breedtegraad,
                    beschrijving));
            }
            return _registratieLijst;
        }

        public void TussenRegistratieToevoegenAanHoofdDatabase(TussenDbOrganisme registratie, Waarneming waarneming)
        {
            using var connection = new SqliteConnection(_HoofdDatabaseConnectie);
            connection.Open();

            string query = @"Insert into Registraties(Waarneming_id, DatumTijd, Breedtegraad, Lengtegraad, Beschrijving) Values(@WaarnemingId, @DatumTijd, @Breedtegraad, @Lengtegraad, @Beschrijving)";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@WaarnemingId", waarneming.WaarnemingId);
            command.Parameters.AddWithValue("@DatumTijd", registratie.DatumTijd);
            command.Parameters.AddWithValue("@Breedtegraad", registratie.Longitude);
            command.Parameters.AddWithValue("@Lengtegraad", registratie.Latitude);
            command.Parameters.AddWithValue("@Beschrijving", registratie.Beschrijving);

            command.ExecuteNonQuery();
        }

        public void WaarnemingToevoegen(TussenDbOrganisme registratie)
        {
            using var connection = new SqliteConnection(_HoofdDatabaseConnectie);
            connection.Open();
            string query = @"Insert into Waarnemingen(NaamOrganisme, DierOfPlant, Soort, Oorsprong, Afkomst) Values(@NaamOrganisme, @DierOfPlant, @Soort, @Oorsprong, @Afkomst)";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@NaamOrganisme", registratie.NaamOrganisme);
            command.Parameters.AddWithValue("@DierOfPlant", registratie.DierOfPlant);
            command.Parameters.AddWithValue("@Soort", registratie.Type);
            command.Parameters.AddWithValue("@Oorsprong", registratie.Oorsprong);
            command.Parameters.AddWithValue("@Afkomst", registratie.Afkomst);
            command.ExecuteNonQuery();

        }
        
        public void RegistratieVerwijderenUitTussenDb(TussenDbOrganisme registratie)
        {
            using var connection = new SqliteConnection( _TussenDatabaseConnectie);
            connection.Open();

            string query = @"Delete From Registraties where Registratie_id = @RegistratieId";

            using var command = new SqliteCommand( query, connection);
            command.Parameters.AddWithValue("@RegistratieId", registratie.RegistratieId);

            command.ExecuteNonQuery();
        }

        
    }
}
