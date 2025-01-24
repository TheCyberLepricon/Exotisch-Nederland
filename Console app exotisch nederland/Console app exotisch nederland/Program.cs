using Console_app_exotisch_nederland.Models;
using Console_app_exotisch_nederland.Presentatie;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography.X509Certificates;
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

namespace Console_app_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DateTime currentDateTime = DateTime.Now;
            bool klaar = false;
            PresentatieProgram _presentatie = new PresentatieProgram();
            while(!klaar)
            {
                Organisme standaard = new Organisme("", "", "", "", "", 22.32312, 22.32312, "");
                Console.WriteLine("Kies een optie:\n\t1. Nieuw Organisme toevoegen\n\t2. Alle organismen (gefilterd) bekijken\n\t3. Afsluiten\n" +
                    "\n\tVoer een getal in!");
                List<double> locatieData = new List<double>();
                int keuze;
                while(true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out keuze))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Voer een geldig getal in!");
                    }
                }
                if (keuze == 1)
                {
                    static string Capitalize(string input)
                    {
                        if (string.IsNullOrEmpty(input))
                            return input;

                        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
                    }
                    string DatumKrijgen()
                    {
                        DateTime now = DateTime.Now;
                        string CorrecteData = now.ToString("yyyy-MM-dd-HH");
                        return CorrecteData;
                    }
                    async void OrganismeLocatie()
                    {
                        using HttpClient client = new HttpClient();
                        string url = "https://freegeoip.app/json/";

                        Console.WriteLine("Locatie opvragen...");
                        string response = await client.GetStringAsync(url);

                        var locationData = JsonSerializer.Deserialize<LocationResponse>(response);
                        locatieData.Add(locationData.latitude);
                        locatieData.Add(locationData.longitude);



                    }
                    Console.WriteLine("Is het een dier of plant?");
                    string dierOfPlant = Console.ReadLine();
                    if (dierOfPlant.ToLower() == "plant")
                    {
                        string PlantTypeVraag()
                        {
                            return _presentatie.PlantTypeAntwoord();
                        }
                        string PlantNaamVraag()
                        {
                            Console.WriteLine("Wat is de naam van de soort?");
                            Console.WriteLine("Vul de alledaagse term in of de wetenschappelijke term voor de soort.");
                            Console.WriteLine("Vul \"Onbekend\" als U geen idee heeft!");
                            return _presentatie.PlantNaamAntwoord(Console.ReadLine());
                        }
                        string PlantAfkomstVraag()
                        {
                            Console.WriteLine("Is de plant \"Inheems\" of \"Exoot\"?");
                            return _presentatie.PlantAfkomstAntwoord(Console.ReadLine());
                        }
                        string PlantOorsprongVraag()
                        {
                            Console.WriteLine("Waar komt de plant vandaan?");
                            Console.WriteLine("Vul een continent in (Europa, Afrika...)");
                            return _presentatie.PlantOorsprongAntwoord(Console.ReadLine());
                        }
                        string BeschrijvingVraag()
                        {
                            Console.WriteLine("Geef een beschrijving van wat U gezien heeft.");
                            return _presentatie.BeschrijvingAntwoord(Console.ReadLine());
                        }
                        OrganismeLocatie();
                        var plantje =new Organisme.Plant("Plant",PlantTypeVraag(), Capitalize(PlantOorsprongVraag()), Capitalize(PlantAfkomstVraag()),
                            DatumKrijgen(), locatieData[0], locatieData[1] , Capitalize(PlantNaamVraag()), Capitalize(BeschrijvingVraag()));
                        _presentatie.VoegPlantToe(plantje);




                    }
                    else if (dierOfPlant.ToLower() == "dier")
                    {
                        string DierTypeVraag()
                        {
                            return _presentatie.DierTypeAntwoord();
                        }
                        string DierNaamVraag()
                        {
                            Console.WriteLine("Wat is de naam van het dier?");
                            Console.WriteLine("Vul de alledaagse term in of de wetenschappelijke term voor het dier.");
                            Console.WriteLine("Vul \"Onbekend\" als U geen idee heeft!");
                            return _presentatie.DierNaamAntwoord(Console.ReadLine());
                        }
                        string DierAfkomstVraag()
                        {
                            Console.WriteLine("Is het dier \"Inheems\" of \"Exoot\"?");
                            return _presentatie.DierAfkomstAntwoord(Console.ReadLine());
                        }
                        string DierOorsprongVraag()
                        {
                            Console.WriteLine("Waar komt het dier vandaan?");
                            Console.WriteLine("Vul een continent in:");
                            Console.WriteLine("Europa, Afrika, Azie, Zuid Amerika, Noord Amerika, Antartica, Oceanie");
                            return _presentatie.DierOorsprongAntwoord(Console.ReadLine());
                        }
                        string BeschrijvingVraag()
                        {
                            Console.WriteLine("Geef een beschrijving van wat U gezien heeft.");
                            return _presentatie.BeschrijvingAntwoord(Console.ReadLine());
                        }

                        OrganismeLocatie();
                        var diertje = new Organisme.Dier("Dier", DierTypeVraag(), Capitalize(DierOorsprongVraag()), Capitalize(DierAfkomstVraag()),
                            DatumKrijgen(), locatieData[0], locatieData[1], Capitalize(DierNaamVraag()), Capitalize(BeschrijvingVraag()));
                        _presentatie.VoegDierToe(diertje);
                    }
                }
                
                else if (keuze == 2)
                {
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
                    Console.WriteLine("Wat wilt u zien?");
                    Console.WriteLine("Kies een van de onderstaande opties:");
                    Console.WriteLine("\t1. Dier\n\t2. Plant\n\t3. Alles");
                    _presentatie.OrganismesBekijken(Console.ReadLine());
                    

                    }
                else if(keuze == 3)
                {
                    break;
                }
            }
        }
        
    }
}
