using Console_app_exotisch_nederland.Presentatie;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
public class LocationResponse
{
    public string ip { get; set; }
    public string countryCode { get; set; }
    public string countryName { get; set; }
    public string regionCode { get; set; }
    public string regionName { get; set; }
    public string city { get; set; }
    public string zipCode { get; set; }
    public string timeZone { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
    public int metroCode { get; set; }
}

namespace Console_app_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool klaar = false;
            PresentatieProgram _presentatie = new PresentatieProgram();
            while(!klaar)
            {
                Console.WriteLine("Kies een optie:\n\t1. Nieuwe Organisme toevoegen\n\t2. Alle organismen bekijken\n\t" +
                    "3. Filteren op ...\n\t4. Afsluiten");
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
                    Console.WriteLine("Is het een dier of plant?");
                    string dierOfPlant = Console.ReadLine();
                    if (dierOfPlant.ToLower() == "plant")
                    {
                        string PlantTypeVraag()
                        {
                            Console.WriteLine("Kies een van de volgende mogelijkheden van plantsoorten:");
                            Console.WriteLine("\t1. Varenachtigen\n\t2. Mosachtigen");
                            Console.WriteLine("\t3. Bloemplanten\n\t4. Naaktzadige");
                            Console.WriteLine("\t5. Onbekend/Geen idee");
                            string typePlantKeuze = Console.ReadLine();
                            if (typePlantKeuze.ToLower() == "varenachtigen" | typePlantKeuze == "1")
                            {
                                Console.WriteLine("Varenachtige Toegevoegd!");
                                return "Varenachtige";
                            }
                            else if (typePlantKeuze.ToLower() == "mosachtigen" | typePlantKeuze == "2")
                            {
                                Console.WriteLine("Mosachtige Toegevoegd!");
                                return "Mosachtige";
                            }
                            else if (typePlantKeuze.ToLower() == "bloemplanten" | typePlantKeuze == "3")
                            {
                                Console.WriteLine("Bloemplant Toegevoegd!");
                                return "Bloemplant";
                            }
                            else if (typePlantKeuze.ToLower() == "naaktzadige" | typePlantKeuze == "4")
                            {
                                Console.WriteLine("Naaktzadige Toegevoegd!");
                                return "Naaktzadige";
                            }
                            else if (typePlantKeuze.ToLower() == "onbekend" | typePlantKeuze == "1" | typePlantKeuze.ToLower() == "geen idee" | typePlantKeuze.ToLower() == "onbekend/geen idee")
                            {
                                Console.WriteLine("Onbekend! Toegevoegd!");
                                return "Onbekend";
                            }
                            else
                            {
                                Console.WriteLine("Geef een geldig antwoord!");
                                return PlantTypeVraag();
                            }
                        }
                        string PlantNaamVraag()
                        {
                            Console.WriteLine("Wat is de naam van de plant?");
                            Console.WriteLine("Vul de alledaagse term in of de wetenschappelijke term voor de plant.");
                            Console.WriteLine("Vul \"Onbekend\" ");
                            string naamPlantKeuzeTemp = Console.ReadLine();
                            return naamPlantKeuzeTemp;
                        }
                        string PlantAfkomstVraag()
                        {
                            Console.WriteLine("Is de plant \"Inheems\" of \"Exoot\"?");
                            string afkomstPlantKeuze = Console.ReadLine();
                            if(afkomstPlantKeuze.ToLower() == "inheems")
                            {
                                return afkomstPlantKeuze;
                            }
                            else if (afkomstPlantKeuze.ToLower() == "exoot")
                            {
                                return afkomstPlantKeuze;
                            }
                            else
                            {
                                Console.WriteLine("Vul \"Inheems\" of \"Exoot\" in!");
                                return PlantAfkomstVraag();
                            }
                        }
                        async void OrganismeLocatie()
                        {
                            using HttpClient client = new HttpClient();

                            try
                            {
                                string url = "https://freegeoip.app/json/";

                                Console.WriteLine("Locatie opvragen...");
                                string response = await client.GetStringAsync(url);

                                var locationData = JsonSerializer.Deserialize<LocationResponse>(response);

                                if (true)
                                {
                                    Console.WriteLine($"Latitude: {locationData.latitude}");
                                    Console.WriteLine($"Longitude: {locationData.longitude}");
                                    Console.WriteLine($"Stad: {locationData.city}");
                                    Console.WriteLine($"Land: {locationData.countryName}");

                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                Console.WriteLine($"Netwerkfout: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Onverwachte fout: {ex.Message}");
                            }
                        }
                        
                        
                        PlantTypeVraag();
                        PlantNaamVraag();
                        PlantAfkomstVraag();
                        OrganismeLocatie();


                    }
                }
            }
        }
        
    }
}
