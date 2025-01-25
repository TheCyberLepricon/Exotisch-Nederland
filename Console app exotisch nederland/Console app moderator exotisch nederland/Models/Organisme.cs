using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class Organisme
    {
        public string NaamOrganisme { get; private set; }
        public string DierOfPlant { get; private set; }
        public string Type { get; private set; }
        public string Oorsprong { get; private set; }
        public string Afkomst { get; private set; }
        public DateTime DatumTijd { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string Beschrijving { get; private set; }
        public Organisme(string naamOrganisme, string dierOfPlant, string type,string oorsprong, string afkomst, DateTime datumTijd, double latitude, double longitude, string beschrijving)
        {
            NaamOrganisme = naamOrganisme;
            DierOfPlant = dierOfPlant;
            Type = type;
            Oorsprong = oorsprong;
            Afkomst = afkomst;
            DatumTijd = datumTijd;
            Latitude = latitude;
            Longitude = longitude;
            Beschrijving = beschrijving;

        }

        public virtual void InformatieOrganisme()
        {
            Console.WriteLine("Algemene informatie organisme");
        }
    }
    

}
