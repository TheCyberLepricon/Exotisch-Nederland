using Console_app_exotisch_nederland.Models;
using Console_app_exotisch_nederland.Presentatie;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Threading.Tasks;
using System;
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
                Organismes standaard = new Organismes("", "", "", "", "", "", "");
                Console.WriteLine("Kies een optie:\n\t1. Nieuw Organisme toevoegen\n\t2. Alle organismen bekijken\n\t" +
                    "3. Filteren op ...\n\t4. Afsluiten\n\n\tVoer een getal in!");
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
                        OrganismeLocatie();
                        var plantje =new Organismes.Plant("Plant",PlantTypeVraag(), Capitalize(PlantOorsprongVraag()), Capitalize(PlantAfkomstVraag()),
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

                        OrganismeLocatie();
                        var diertje = new Organismes.Plant("Dier", DierTypeVraag(), Capitalize(DierOorsprongVraag()), Capitalize(DierAfkomstVraag()),
                            DatumKrijgen(), locatieData[0], locatieData[1], Capitalize(DierNaamVraag()));
                        standaard.VoegPlantToe(diertje);
                    }
                }
                else if (keuze == 2)
                {
                    foreach (Organismes.Plant organisme in Organismes.Plant.plantenLijst)
                    {
                        organisme.Beschrijving();
                    }
                }
                else if(keuze == 4)
                {
                    break;
                }
            }
        }
        
    }
}
