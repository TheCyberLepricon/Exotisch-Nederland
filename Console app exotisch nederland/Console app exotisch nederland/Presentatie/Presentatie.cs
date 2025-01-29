using Console_app_exotisch_nederland.Business;
using Console_app_exotisch_nederland.Models;
using System.Globalization;
using System.Text.Json;
namespace Console_app_exotisch_nederland.Presentatie
{
    internal class PresentatieProgram
    {
        public class LocationResponse
        {
            public string ip { get; set; }
            public string country_code { get; set; }
            public string country_name { get; set; }
            public string region_code { get; set; }
            public string region_name { get; set; }
            public string city { get; set; }
            public string zip_code { get; set; }
            public string time_zone { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int metro_code { get; set; }
        }
        List<double> LocatieKrijgen()
        {
            List<double> locatieData = new List<double>();
            async void Locatiekrijgen()
            {
                using HttpClient client = new HttpClient();
                string url = "https://freegeoip.app/json/";

                Console.WriteLine("Locatie opvragen...");
                string response = await client.GetStringAsync(url);

                var locationData = JsonSerializer.Deserialize<LocationResponse>(response);
                locatieData.Add(locationData.latitude);
                locatieData.Add(locationData.longitude);



            }
            Locatiekrijgen();
            Thread.Sleep(1000);
            return locatieData;
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
                return PlantAfkomstAntwoord(Console.ReadLine());
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
                return PlantOorsprongAntwoord(Console.ReadLine());
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
                return DierOorsprongAntwoord(Console.ReadLine());
            }
            else
            {
                return oorsprongDierChecked;
            }
        }
        public string DierAfkomstAntwoord(string afkomstDierKeuze)
        {
            string afkomstDier = _business.DierAfkomst(afkomstDierKeuze);
            if (afkomstDier == "GGA")
            {
                return DierAfkomstAntwoord(Console.ReadLine());
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
            int gevondenOrganismes = 0;
            List<double> locatieData = LocatieKrijgen();
            if (organismesBekijken == "1" | organismesBekijken.ToLower() == "dier")
            {
                foreach(Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
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
                        if (CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude) < 5){
                            gevondenOrganismes++;
                            Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                            $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                            $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                            Console.WriteLine($"Het dier is: {CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude)}km van u vandaan");
                        }

                    }
                }
                if (gevondenOrganismes == 0)
                {
                    Console.WriteLine($"Er is geen geregistreerd dier in de buurt!");
                }
                return "";
            }
            else if (organismesBekijken == "2" | organismesBekijken.ToLower() == "plant")
            {
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
                        if (CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude) < 5)
                        {
                            gevondenOrganismes++;
                            Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                            $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                            $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                            Console.WriteLine($"De plant is: {CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude)}km van u vandaan");
                        }
                    }
                }
                if (gevondenOrganismes == 0)
                {
                    Console.WriteLine($"Er is geen geregistreerde plant in de buurt!");
                }
                return "";
            }
            else if (organismesBekijken == "3" | organismesBekijken.ToLower() == "alles")
            {
                foreach (Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
                {
                    string[] opgesplitsteDatumTijd = totaalOrganisme.DatumTijd.Split("-");
                    int Dag = int.Parse(opgesplitsteDatumTijd[0]);
                    int Maand = int.Parse(opgesplitsteDatumTijd[1]);
                    int Jaar = int.Parse(opgesplitsteDatumTijd[2]);
                    int Uur = int.Parse(opgesplitsteDatumTijd[3]);
                    DateTime datumTijdNieuwe = new DateTime(Jaar, Maand, Dag, Uur, 0, 0);
                    if (CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude) < 5)
                    {
                        gevondenOrganismes++;
                        Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                        $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                        $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                        Console.WriteLine($"De plant is: {CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude)}km van u vandaan");
                    }
                }
                if (gevondenOrganismes == 0)
                {
                    Console.WriteLine($"Er is geen registratie in de buurt!");
                }
                return "";
            }
            else if (organismesBekijken == "4" | organismesBekijken.ToLower() == "specifieke soort")
            {
                Console.WriteLine("Welk organisme zou u willen zien?");
                string specifiekeSoort = Console.ReadLine();
                foreach (Organisme.TotaalOrganismes totaalOrganisme in _business.AlleOrganismes())
                {
                    string[] opgesplitsteDatumTijd = totaalOrganisme.DatumTijd.Split("-");
                    int Dag = int.Parse(opgesplitsteDatumTijd[0]);
                    int Maand = int.Parse(opgesplitsteDatumTijd[1]);
                    int Jaar = int.Parse(opgesplitsteDatumTijd[2]);
                    int Uur = int.Parse(opgesplitsteDatumTijd[3]);
                    DateTime datumTijdNieuwe = new DateTime(Jaar, Maand, Dag, Uur, 0, 0);
                    if (totaalOrganisme.NaamOrganisme.ToLower() == specifiekeSoort.ToLower())
                    {
                        if (CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude) < 5)
                        {
                            gevondenOrganismes++;
                            Console.WriteLine($"Naam: {totaalOrganisme.NaamOrganisme}\nType: {totaalOrganisme.Type}" +
                            $"\nOorpsrong: {totaalOrganisme.Oorsprong}\nAfkomst: {totaalOrganisme.Afkomst}" +
                            $"\nDatum: {datumTijdNieuwe.ToString("dd-MM-yyyy")}\nUur: {datumTijdNieuwe.ToString("HH")}\nBeschrijving: {totaalOrganisme.Beschrijving}");
                            Console.WriteLine($"Het organisme is: {CalculateDistance(locatieData[0], totaalOrganisme.Latitude, locatieData[1], totaalOrganisme.Longitude)}km van u vandaan");
                        }
                    }
                }
                if(gevondenOrganismes == 0)
                {
                    Console.WriteLine($"Er is geen {specifiekeSoort} in de buurt!");
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