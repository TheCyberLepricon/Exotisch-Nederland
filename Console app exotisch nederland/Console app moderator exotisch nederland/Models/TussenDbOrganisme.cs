using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class TussenDbOrganisme : Organisme
    {
        public int RegistratieId {  get; private set; }

        public TussenDbOrganisme(int registratieId, string naamOrganisme, string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string beschrijving) 
        : base(naamOrganisme, dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude, beschrijving)
        {
            RegistratieId = registratieId;
        }

        public override void InformatieOrganisme()
        {
            Console.WriteLine("Gegevens organisme:");
            Console.WriteLine($"|Registratie id: {RegistratieId}\n" +
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
