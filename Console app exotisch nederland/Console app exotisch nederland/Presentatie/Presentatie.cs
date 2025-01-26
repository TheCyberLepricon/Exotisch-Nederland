using Console_app_exotisch_nederland.Business;
using Console_app_exotisch_nederland.Models;
using System.Globalization;
using System.Text;
using System.Text.Json;
namespace Console_app_exotisch_nederland.Presentatie
{
    internal class PresentatieProgram
    {
        public class LocationResponse
        {
            public static string Ip { get; set; }
            public static string CountryCode { get; set; }
            public static string CountryName { get; set; }
            public static string RegionCode { get; set; }
            public static string RegionName { get; set; }
            public static string City { get; set; }
            public static string ZipCode { get; set; }
            public static string TimeZone { get; set; }
            public static double Latitude { get; set; }
            public static double Longitude { get; set; }
        }
        public static async Task LocatieKrijgen()
        {
            using HttpClient client = new HttpClient();
            string url = "https://freegeoip.app/json/";

            Console.WriteLine("Locatie opvragen...");
            string response = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Zorgt voor insensitiviteit
            };

            var locationData = JsonSerializer.Deserialize<LocationResponse>(response, options);

        }
        static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        double CalculateDistance(double lat1, double lat2, double lon1, double lon2)
        {
            const double R = 6371;
            //R = straal van de aarde in km


            double lat1Rad = DegreesToRadians(lat1);
            double lat2Rad = DegreesToRadians(lat2);
            double lon1Rad = DegreesToRadians(lon1);
            double lon2Rad = DegreesToRadians(lon2);



            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
            Math.Cos(lat1) * Math.Cos(lat2) *
            Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;
            return distance;
        }

        BusinessProgram _business = new BusinessProgram();
        public void VoegDierToe(Organisme.Dier dier)
        {
            _business.VoegDierToe(dier);
        }
        public void VoegPlantToe(Organisme.Plant plant)
        {
            _business.VoegPlantToe(plant);
        }



        public string PlantTypeAntwoord()
        {
            Console.WriteLine("Kies een van de volgende mogelijkheden van plantsoorten:");
            Console.WriteLine("\t1. Varenachtigen\n\t2. Mosachtigen");
            Console.WriteLine("\t3. Bloemplanten\n\t4. Naaktzadige");
            Console.WriteLine("\t5. Onbekend/Geen idee");
            string typePlantKeuze = _business.PlantType(Console.ReadLine());
            if(typePlantKeuze == "GGA")
            {
                return PlantTypeAntwoord();
            }
            else
            {
                return typePlantKeuze;
            }
        }
        public string PlantNaamAntwoord(string plantNaam)
        {
            string nullChecked = _business.NullCheck(plantNaam);
            if (nullChecked == "Null")
            {
                Console.WriteLine("Vul iets in!");
                return PlantNaamAntwoord(Console.ReadLine());
            }
            else
            {
                return plantNaam;
            }
        }
        public string PlantAfkomstAntwoord(string afkomstPlantKeuze)
        {
            string afkomstPlant = _business.PlantAfkomst(afkomstPlantKeuze);
            if (afkomstPlant == "GGA")
            {
                return PlantAfkomstAntwoord(afkomstPlantKeuze);
            }
            else
            {
                return afkomstPlant;
            }
        }
        public string PlantOorsprongAntwoord(string oorsprongPlant)
        {
            string plantOorsprong = _business.PlantOorsprong(oorsprongPlant);
            if(plantOorsprong == "GGA")
            {
                return PlantOorsprongAntwoord(oorsprongPlant);
            }
            else
            {
                return plantOorsprong;
            }
        }

        public string DierTypeAntwoord()
        {
            return _business.DierType();
        }
        public string DierNaamAntwoord(string dierNaam)
        {
            string dierNaamChecked = _business.NullCheck(dierNaam);
            if ( dierNaamChecked == "Null")
            {
                Console.WriteLine("Vul iets in!");
                return DierNaamAntwoord(Console.ReadLine());
            }
            else
            {
                return dierNaamChecked;
            }

        }
        public string DierOorsprongAntwoord(string oorsprongDier)
        {
            string oorsprongDierChecked = _business.DierOorsprong(oorsprongDier);
            if(oorsprongDierChecked == "GGA")
            {
                return DierOorsprongAntwoord(oorsprongDier);
            }
            else
            {
                return oorsprongDierChecked;
            }
        }
        public string DierAfkomstAntwoord(string afkomstDierKeuze)
        {
            string afkomstDier = _business.PlantAfkomst(afkomstDierKeuze);
            if (afkomstDier == "GGA")
            {
                return PlantAfkomstAntwoord(afkomstDierKeuze);
            }
            else
            {
                return afkomstDier;
            }
        }
        public string BeschrijvingAntwoord(string beschrijving)
        {
            string beschrijvingChecked = _business.NullCheck(beschrijving);
            if (beschrijvingChecked == "Null")
            {
                Console.WriteLine("Vul iets in!");
                return DierNaamAntwoord(Console.ReadLine());
            }
            else
            {
                return beschrijvingChecked;
            }
        }
        public string OrganismesBekijken(string organismesBekijken)
        {
            LocatieKrijgen();
            if (organismesBekijken == "1" | organismesBekijken.ToLower() == "dier")
            {
                int count = 0;
                foreach (Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
                {
                    // totaalOrganisme.DatumTijd komt binnen als een string, die wordt opgesplitst in integers en dan in de DateTime variabele gezet
                    string[] opgesplitsteDatumTijd = totaalOrganisme.DatumTijd.Split("-");
                    int Dag = int.Parse(opgesplitsteDatumTijd[0]);
                    int Maand = int.Parse(opgesplitsteDatumTijd [1]);
                    int Jaar = int.Parse(opgesplitsteDatumTijd[2]);
                    int Uur = int.Parse(opgesplitsteDatumTijd[3]);
                    DateTime datumTijdNieuwe = new DateTime(Jaar, Maand,Dag, Uur, 0, 0);
                    if (totaalOrganisme.DierOfPlant == "Dier")
                    {
                        if (CalculateDistance(LocationResponse.Latitude , totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude) < 5){
                            count ++;
                            Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                            $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                            $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                            Console.WriteLine($"Het dier is: {CalculateDistance(LocationResponse.Latitude, totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude)}km van u vandaan");
                        }
                        

                    }
                }
                if (count == 0){
                    Console.WriteLine("Er zijn geen organismes in de buurt");
                }
                return "";
            }
            else if (organismesBekijken == "2" | organismesBekijken.ToLower() == "plant")
            {
                int count = 0;
                foreach (Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
                {
                    string[] opgesplitsteDatumTijd = totaalOrganisme.DatumTijd.Split("-");
                    int Dag = int.Parse(opgesplitsteDatumTijd[0]);
                    int Maand = int.Parse(opgesplitsteDatumTijd[1]);
                    int Jaar = int.Parse(opgesplitsteDatumTijd[2]);
                    int Uur = int.Parse(opgesplitsteDatumTijd[3]);
                    DateTime datumTijdNieuwe = new DateTime(Jaar, Maand, Dag, Uur, 0, 0);
                    if (totaalOrganisme.DierOfPlant == "Plant")
                    {
                        if (CalculateDistance(LocationResponse.Latitude, totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude) < 5)
                        {
                            count++;
                            Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                            $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                            $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                            Console.WriteLine($"De plant is: {CalculateDistance(LocationResponse.Latitude, totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude)}km van u vandaan");
                        }
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Er zijn geen organismes in de buurt");
                }
                return "";
            }
            else if (organismesBekijken == "3" | organismesBekijken.ToLower() == "alles")
            {
                int count = 0;
                foreach (Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
                {
                    string[] opgesplitsteDatumTijd = totaalOrganisme.DatumTijd.Split("-");
                    int Dag = int.Parse(opgesplitsteDatumTijd[0]);
                    int Maand = int.Parse(opgesplitsteDatumTijd[1]);
                    int Jaar = int.Parse(opgesplitsteDatumTijd[2]);
                    int Uur = int.Parse(opgesplitsteDatumTijd[3]);
                    DateTime datumTijdNieuwe = new DateTime(Jaar, Maand, Dag, Uur, 0, 0);
                    if (CalculateDistance(LocationResponse.Latitude, totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude) < 5)
                    {
                        count++;
                        Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                        $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                        $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                        Console.WriteLine($"De plant is: {CalculateDistance(LocationResponse.Latitude, totaalOrganisme.Latitude, LocationResponse.Latitude, totaalOrganisme.Longitude)}km van u vandaan");
                    }
                    
                }
                if (count == 0)
                {
                    Console.WriteLine("Er zijn geen organismes in de buurt");
                }
                return "";
            }
            else
            {
                if(_business.GeenGeldigeKeuze() == "GGA")
                {
                    return OrganismesBekijken(Console.ReadLine());
                }
                else
                {
                    return "";
                }
            }
        }
    
    
    
    }
}