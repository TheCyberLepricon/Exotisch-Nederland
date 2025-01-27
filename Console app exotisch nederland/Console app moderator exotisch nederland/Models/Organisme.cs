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
        public string DatumTijd { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string Beschrijving { get; private set; }
        public Organisme(string naamOrganisme, string dierOfPlant, string type,string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string beschrijving)
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

        public virtual string HernoemOrganisme(string NieuweNaam)
        {
            NaamOrganisme = NieuweNaam; 
            return NaamOrganisme;
        }

        public virtual string VeranderType(string NieuweType)
        {
            DierOfPlant = NieuweType;
            return DierOfPlant;
        }

        public virtual string VeranderSoort(string NieuweSoort)
        {
            Type = NieuweSoort;
            return Type;
        }

        public virtual string VeranderOorsprong(string NieuweOorsprong)
        {
            Oorsprong = NieuweOorsprong;
            return Oorsprong;
        }

        public virtual string VeranderAfkomst(string NieuweAfkomst)
        {
            Afkomst = NieuweAfkomst;
            return Afkomst;
        }

        public virtual string VeranderBeschrijving(string NieuweBeschrijving)
        {
            Beschrijving = NieuweBeschrijving;
            return Beschrijving;
        }
    }
    

}
