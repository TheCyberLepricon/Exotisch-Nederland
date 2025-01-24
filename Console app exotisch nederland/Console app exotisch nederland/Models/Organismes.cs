namespace Console_app_exotisch_nederland.Models
{


    public class Organisme
    {

        public void VoegPlantToe(Plant organisme)
        {
            Plant.plantenLijst.Add(organisme);
        }

        public virtual void BeschrijvingGeven()
        {
            Console.WriteLine($"Dit hoort niet op dit scherm te staan......");
        }
        public string DierOfPlant { get; private set; }
        public string Type { get; private set; }
        public string Oorsprong { get; private set; }
        public string Afkomst { get; private set; }
        public string DatumTijd { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string Beschrijving { get; private set; }
        public Organisme(string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string beschrijving)
        {
            DierOfPlant = dierOfPlant;
            Oorsprong = oorsprong;
            Afkomst = afkomst;
            DatumTijd = datumTijd;
            Latitude = latitude;
            Longitude = longitude;
            Type = type;
            Beschrijving = beschrijving;

        }
        public class Plant : Organisme
        {
            public string NaamPlant { get; private set; }
            public static List<Plant> plantenLijst = new List<Plant>();
            public Plant(string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string naamPlant, string beschrijving) :
                base(dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude, beschrijving)
            {
                NaamPlant = naamPlant;
            }
            public override void BeschrijvingGeven()
            {
                Console.WriteLine($"dierOfPlant = {DierOfPlant}\ntype = {Type}\noorsprong = {Oorsprong}\nafkomst = {Afkomst}\ndatumTijd =" +
                    $" {DatumTijd}\nlatitude = {Latitude}\nlongitude = {Longitude}\nnaamPlant = {NaamPlant}");
            }
        }
        public class Dier : Organisme
        {
            public string NaamDier { get; private set; }
            public static List<Dier> dierenLijst = new List<Dier>();
            public Dier(string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string naamDier, string beschrijving) :
                        base(dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude, beschrijving)
            {
                NaamDier = naamDier;
            }
            public override void BeschrijvingGeven()
            {
                Console.WriteLine($"dierOfPlant = {DierOfPlant}\ntype = {Type}\noorsprong = {Oorsprong}\nafkomst = {Afkomst}\ndatumTijd =" +
                    $" {DatumTijd}\nlatitude = {Latitude}\nlongitude = {Longitude}\nnaamDier = {NaamDier}");
            }
        }
        public class TotaalOrganismes : Organisme
        {
            public string NaamOrganisme { get; private set; }

            public TotaalOrganismes(string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, double latitude, double longitude, string naamOrganisme, string beschrijving) :
                        base(dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude, beschrijving)
            {
                NaamOrganisme = naamOrganisme;
            }
        }
    }
}

    