using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class HoofDbOrganisme : Organisme
    {
        public int WaarnemingId { get; private set; }

        public HoofDbOrganisme(int waarnemingId, string naamOrganisme, string dierOfPlant, string type, string oorsprong, string afkomst, DateTime datumTijd, double latitude, double longitude, string beschrijving) 
        : base(naamOrganisme, dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude, beschrijving)
        {
            WaarnemingId = waarnemingId;
        }

        public override void InformatieOrganisme()
        {
            Console.WriteLine("Gegevens organisme:");
            Console.WriteLine($"|Registratie id: {WaarnemingId}\n" +
                $"| Naam: {NaamOrganisme}\n" +
                $"| Type organisme: {DierOfPlant}\n" +
                $"| Soort: {Type}\n" +
                $"| Oorsprong: {Oorsprong}\n" +
                $"| Afkomst: {Afkomst}\n" +
                $"| Datum/Tijd: {DatumTijd}\n" +
                $"| Lengtegraad: {Latitude}\n" +
                $"| Breedtegraad: {Longitude}\n" +
                $"| Beschrijving: {Beschrijving}\n");
        }
        

    }
}
