using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class Registratie
    {
        public int RegistratieId { get; set; }
        public int WaarnemingId { get; set; }
        public string DatumTijd { get; set; }
        public double Lengtegraad {  get; set; }
        public double Breedtegraad { get; set; }
        public string Beschrijving {  get; set; }

        public Registratie(int registratieId, int waarnemingId, string datumTijd, double lengtegraad, double breedtegraad, string beschrijving)
        {
            RegistratieId = registratieId;
            WaarnemingId = waarnemingId;
            DatumTijd = datumTijd;
            Lengtegraad = lengtegraad;
            Breedtegraad = breedtegraad;
            Beschrijving = beschrijving;
        }

        public void RegistratieInformatie()
        {
            Console.WriteLine("Gegevens organisme:");
            Console.WriteLine($"|Registratie id: {RegistratieId}\n" +
                $"| Waarneming id: {WaarnemingId}\n" +
                $"| Datum/tijd: {DatumTijd}\n" +
                $"| Lengtegraad: {Lengtegraad}\n" +
                $"| Breedtegraad: {Breedtegraad}\n" +
                $"| Beschrijving: {Beschrijving}\n");
        }
    }
}
