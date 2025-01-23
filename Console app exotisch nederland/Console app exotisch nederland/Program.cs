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
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
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
                Organisme standaard = new Organisme("", "", "", "", "", "", "");
                Console.WriteLine("Kies een optie:\n\t1. Nieuw Organisme toevoegen\n\t2. Alle organismen (gefilterd) bekijken\n\t3. Afsluiten\n" +
                    "\n\tVoer een getal in!");
                List<string> locatieData = new List<string>();
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
                        locatieData.Add(locationData.latitude.ToString());
                        locatieData.Add(locationData.longitude.ToString());
                        locatieData.Add(locationData.city.ToString());
                        locatieData.Add(locationData.region_name.ToString());



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
                        string Beschrijvingvraa()
                        {
                            Console.WriteLine("Geef een beschrijving van wat U gezien heeft.");
                            return _presentatie.BeschrijvingAntwoord(Console.ReadLine());
                        }
                        OrganismeLocatie();
                        var plantje =new Organisme.Plant("Plant",PlantTypeVraag(), Capitalize(PlantOorsprongVraag()), Capitalize(PlantAfkomstVraag()),
                            DatumKrijgen(), locatieData[0], locatieData[1] , Capitalize(PlantNaamVraag()));
                        standaard.VoegPlantToe(plantje);




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
                            DatumKrijgen(), locatieData[0], locatieData[1], Capitalize(DierNaamVraag()));
                        _presentatie.VoegOrganismeToe(diertje);
                    }
                }
                
                else if (keuze == 2)
                {
                    static double DegreesToRadians(double degrees)
                    {
                        return degrees * Math.PI / 180;
                    }
                    double CalculateDistance(decimal lat1decimal, decimal lat2decimal, decimal lon1decimal, decimal lon2decimal)
                    {
                        const double R = 6371;
                        //R = straal van de aarde in km

                        double lat1 = Convert.ToDouble(lat1decimal);
                        double lat2 = Convert.ToDouble(lat2decimal);
                        double lon1 = Convert.ToDouble(lon1decimal);
                        double lon2 = Convert.ToDouble(lon2decimal);

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
                    
                    foreach (Organismes.Plant organisme in Organismes.Plant.plantenLijst)
                    {
                        //52.091106, 5.122004
                        double lat2temp = 52.091106;
                        double lon2temp = 5.122004;
                        if (CalculateDistance(Convert.ToDecimal(organisme.Latitude), Convert.ToDecimal(lat2temp), Convert.ToDecimal(organisme.Longitude) , Convert.ToDecimal(lon2temp)) > 5)
                        {
                            Console.WriteLine("Dit is te ver");
                            Console.WriteLine(CalculateDistance(Convert.ToDecimal(organisme.Latitude), Convert.ToDecimal(lat2temp), Convert.ToDecimal(organisme.Longitude), Convert.ToDecimal(lon2temp)));
                            organisme.Beschrijving();
                        }
                        else
                        {
                            organisme.Beschrijving();
                        }
                    }
                }
                else if(keuze == 3)
                {
                    break;
                }
            }
        }
        
    }
}
