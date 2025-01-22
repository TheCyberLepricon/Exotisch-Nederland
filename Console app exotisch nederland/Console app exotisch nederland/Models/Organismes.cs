namespace Console_app_exotisch_nederland.Models
{
    
    
    public class Organismes
    {
        
        public void VoegPlantToe(Plant organisme)
        {
            Plant.plantenLijst.Add(organisme);
        }
        public void VoegDierToe(Dier organisme)
        {
            Dier.dierenLijst.Add(organisme);
        }
        public virtual void Beschrijving()
        {
            Console.WriteLine($"Dit hoort niet op dit scherm te staan......");
        }
        public string DierOfPlant { get; private set; }
        public string Type { get; private set; }
        public string Oorsprong { get; private set; }
        public string Afkomst { get; private set; }
        public string DatumTijd { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public Organismes(string dierOfPlant, string type, string oorsprong, string afkomst, string datumTijd, string latitude, string longitude)
        {
            DierOfPlant = dierOfPlant;
            Oorsprong = oorsprong;
            Afkomst = afkomst;
            DatumTijd = datumTijd;
            Latitude = latitude;
            Longitude = longitude;
            Type = type;
        }
        public class Plant : Organismes
        {
            public string NaamPlant { get; private set; }
            public static List<Plant> plantenLijst = new List<Plant>();
            public Plant(string dierOfPlant,string type, string oorsprong, string afkomst, string datumTijd, string latitude, string longitude, string naamPlant) :
                base(dierOfPlant,type, oorsprong, afkomst, datumTijd, latitude, longitude)
            {
                NaamPlant = naamPlant;
            }
            public override void Beschrijving()
            {
                Console.WriteLine($"dierOfPlant = {DierOfPlant}\ntype = {Type}\noorsprong = {Oorsprong}\nafkomst = {Afkomst}\ndatumTijd =" +
                    $" {DatumTijd}\nlatitude = {Latitude}\nlongitude = {Longitude}\nnaamPlant = {NaamPlant}");
            }
        }
        public class Dier : Organismes
        {
            public string NaamDier { get; private set; }
            public static List<Dier> dierenLijst = new List<Dier>();
            public Dier(string dierOfPlant,string type, string oorsprong, string afkomst, string datumTijd, string latitude, string longitude, string naamDier) :
                        base(dierOfPlant, type, oorsprong, afkomst, datumTijd, latitude, longitude)
            {
                NaamDier = naamDier;
            }
            public override void Beschrijving()
            {
                Console.WriteLine($"dierOfPlant = {DierOfPlant}\ntype = {Type}\noorsprong = {Oorsprong}\nafkomst = {Afkomst}\ndatumTijd =" +
                    $" {DatumTijd}\nlatitude = {Latitude}\nlongitude = {Longitude}\nnaamDier = {NaamDier}");
            }
        }
    }
    
}

    